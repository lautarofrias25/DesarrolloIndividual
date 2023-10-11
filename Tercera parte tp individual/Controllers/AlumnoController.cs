using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;
using Tercera_parte_tp_individual.Data;
using Microsoft.EntityFrameworkCore;

namespace Tercera_parte_tp_individual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly TP3Context _context;
        public AlumnoController(TP3Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<GetAlumnoDto>>> GetAlumnos()
        {
            var alumnos = await _context.Alumnos.ToListAsync();
            var alumnosDto = new List<GetAlumnoDto>();
            foreach (var alumno in alumnos)
            {
                var alumnoDto = new GetAlumnoDto();
                alumnoDto.id = alumno.id;
                alumnoDto.nombre = alumno.nombre;
                alumnoDto.apellido = alumno.apellido;
                alumnoDto.legajo = alumno.legajo;
                alumnoDto.CarreraId = alumno.CarreraId;
                alumnosDto.Add(alumnoDto);
            }
            if (alumnos == null)
            {
                return NoContent();
            }
            return Ok(alumnosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAlumnoDto>> GetAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            var alumnoDto = new GetAlumnoDto();
            alumnoDto.id = alumno.id;
            alumnoDto.nombre = alumno.nombre;
            alumnoDto.apellido = alumno.apellido;
            alumnoDto.legajo = alumno.legajo;
            alumnoDto.CarreraId = alumno.CarreraId;
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumnoDto);
        }

        [HttpPost]
        public async Task<ObjectResult> PostAlumno([FromBody] CreateAlumnoDto alumno)
        {
            var carrera = await _context.Carreras.FindAsync(alumno.CarreraId);
            if (carrera != null)
            {
                Alumno alumnoToPost = new Alumno();
                alumnoToPost.nombre = alumno.nombre;
                alumnoToPost.apellido = alumno.apellido;
                alumnoToPost.legajo = alumno.legajo;
                alumnoToPost.carrera = carrera;
                await _context.Alumnos.AddAsync(alumnoToPost);
                await _context.SaveChangesAsync();
                
            }
            if (carrera == null) 
            { 
            return NotFound("Carrera no encontrada");
            }
            return Ok("Alumno creado correctamente");
        }

        /*[HttpPut]
        public async Task<ActionResult<Carrera>> PutCarrera(UpdateCarreraDto carreraDto)
        {
            var dbCarrera = await _context.Carreras.FindAsync(carreraDto.id);
            if (dbCarrera == null)
            {
                return NotFound();
            }

            if (carreraDto.nombre.Length != 0)
            {
                dbCarrera.nombre = carreraDto.nombre;
            }
            if (carreraDto.descripcion.Length != 0)
            {
                dbCarrera.descripcion = carreraDto.descripcion;
            }
            await _context.SaveChangesAsync();

            return Ok(dbCarrera);
        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult<Alumno>> DeleteAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
            return Ok(alumno);
        }
    }
}
