using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;
using Tercera_parte_tp_individual.Data;
using Microsoft.EntityFrameworkCore;
using Tercera_parte_tp_individual.Services;

namespace Tercera_parte_tp_individual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _service;
        public AlumnoController(TP3Context context, IAlumnoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<GetAlumnoDto>>> GetAlumnosAsync()
        {
            var alumnos = await _service.GetAlumnos();
            if (alumnos == null)
            {
                return NoContent();
            }
            return Ok(alumnos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAlumnoDto>> GetAlumnoAsync(int id)
        {
            var alumno = await _service.GetAlumno(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumnoAsync([FromBody] CreateAlumnoDto alumno)
        {
            var alumnot = await _service.PostAlumno(alumno);
            if (alumnot == null)
            {
                return NotFound("Carrera no encontrada");
            }
            return Ok(alumnot);
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
        public async Task<ActionResult<Alumno>> DeleteAlumnoAsync(int id)
        {
            var alumno = await _service.DeleteAlumno(id);
            if (alumno == null)
            {
                return NotFound(alumno);
            }
            return Ok(alumno);
        }
    }
}
