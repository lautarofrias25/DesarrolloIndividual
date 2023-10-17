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

        [HttpPut]
        public async Task<ActionResult<Alumno>> PutAlumno(UpdateAlumnoDto alumnoDto)
        {
            var alumnoMod = await _service.PutAlumno(alumnoDto);
            if (alumnoMod == null)
            {
                return NotFound();
            }
            return Ok(alumnoMod);
        }

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
