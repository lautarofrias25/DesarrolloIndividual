using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Tercera_parte_tp_individual.Data;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tercera_parte_tp_individual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly TP3Context _context;
        public CarreraController(TP3Context context) 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<GetCarreraDto>>> GetCarreras()
        {
            try
            {
                var carreras = await _context.Carreras.ToListAsync();
                if (carreras == null)
                {
                    return NoContent();
                }
                var alumnos = await _context.Alumnos.ToListAsync();
                var carrerasDto = new List<GetCarreraDto>();
                if (alumnos != null)
                {
                    foreach (var carrera in carreras)
                    {
                        var carreraDto = new GetCarreraDto
                        {
                            id = carrera.id,
                            nombre = carrera.nombre,
                            descripcion = carrera.descripcion,
                            alumnos = new List<GetAlumnoDto>()
                        };
                        var alumnoscond = alumnos.Where(a => a.CarreraId == carreraDto.id);
                        foreach (var alumno in alumnoscond)
                        {
                            GetAlumnoDto alumnoDto = new GetAlumnoDto();
                            alumnoDto.id = alumno.id;
                            alumnoDto.nombre = alumno.nombre;
                            alumnoDto.apellido = alumno.apellido;
                            alumnoDto.legajo = alumno.legajo;
                            alumnoDto.CarreraId = alumno.CarreraId;
                            carreraDto.alumnos.Add(alumnoDto);
                        }
                        carrerasDto.Add(carreraDto);
                    }
                }
                return Ok(carrerasDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarreraDto>> GetCarrera(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            var carreraDto = new GetCarreraDto
            {
                id = carrera.id,
                nombre = carrera.nombre,
                descripcion = carrera.descripcion,
                alumnos = new List<GetAlumnoDto>()
            };
            var alumnos = await _context.Alumnos.ToListAsync();
            foreach (var alumno in alumnos.Where(a => a.CarreraId == id))
            {
                var alumnoDto = new GetAlumnoDto
                {
                    id = alumno.id,
                    nombre = alumno.nombre,
                    apellido = alumno.apellido,
                    legajo = alumno.legajo,
                    CarreraId = carrera.id,
                };
                carreraDto.alumnos.Add(alumnoDto);            };
            return Ok(carreraDto) ;
        }

        [HttpPost]
        public async Task<OkObjectResult> PostCarrera([FromBody] CreateCarreraDto carrera)
        {
            Carrera carreraToPost = new Carrera();
            carreraToPost.nombre = carrera.nombre;
            carreraToPost.descripcion = carrera.descripcion;
            await _context.Carreras.AddAsync(carreraToPost);
            await _context.SaveChangesAsync();
            return Ok("Carrera creada correctamente");
        }

        [HttpPut]
        public async Task<ActionResult<Carrera>> PutCarrera(UpdateCarreraDto carreraDto)
        {
            var dbCarrera = await _context.Carreras.FindAsync(carreraDto.id);
            if(dbCarrera == null)
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
        }
        /*[HttpPut]
        public async Task<ActionResult<Carrera>> AddAlumno (int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult<Carrera>> DeleteCarrera(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            _context.Carreras.Remove(carrera);
            await _context.SaveChangesAsync();
            return Ok(carrera);
        }

    }
}
