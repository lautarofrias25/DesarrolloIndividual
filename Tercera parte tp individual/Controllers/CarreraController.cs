using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Tercera_parte_tp_individual.Data;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;
using Tercera_parte_tp_individual.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tercera_parte_tp_individual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly TP3Context _context;
        private readonly CarreraService _service;
        public CarreraController(TP3Context context, CarreraService service) 
        {
            _context = context;
            _service = service;
        }
        [HttpGet]
        public ActionResult<ICollection<GetCarreraDto>> GetCarreras()
        {
            var carrerasDto = _service.GetCarreras();
            if (carrerasDto == null)
            {
                return NotFound(carrerasDto);
            }
            return Ok(carrerasDto);
        }

        [HttpGet("{id}")]
        public ActionResult<GetCarreraDto> GetCarrera(int id)
        {
            var carreraDto = _service.GetCarrera(id);
            if (carreraDto == null)
            {
                return NotFound(carreraDto);
            }
            return Ok(carreraDto);
        }

        [HttpPost]
        public OkObjectResult PostCarrera([FromBody] CreateCarreraDto carrera)
        {
            _service.PostCarrera(carrera);
            return Ok("Carrera creada correctamente");
        }

        [HttpPut]
        public ActionResult<Carrera> PutCarrera(UpdateCarreraDto carreraDto)
        {
            var dbCarrera = _service.PutCarrera(carreraDto);

            return Ok(dbCarrera);
        }
        /*[HttpPut]
        public async Task<ActionResult<Carrera>> AddAlumno (int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

        }*/

        [HttpDelete("{id}")]
        public ActionResult<Carrera> DeleteCarrera(int id)
        {
            var carrera = _service.DeleteCarrera(id);
            if (carrera == null)
            {
                return NotFound(carrera);
            }
            return Ok(carrera);
        }

    }
}
