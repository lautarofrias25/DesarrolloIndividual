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
        private readonly ICarreraService _service;
        public CarreraController(TP3Context context, ICarreraService service) 
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<GetCarreraDto>>> GetCarrerasAsync()
        {
            var carrerasDto = await _service.GetCarreras();
            if (carrerasDto == null)
            {
                return NotFound(carrerasDto);
            }
            return Ok(carrerasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarreraDto>> GetCarreraAsync(int id)
        {
            var carreraDto = await _service.GetCarrera(id);
            if (carreraDto == null)
            {
                return NotFound(carreraDto);
            }
            return Ok(carreraDto);
        }

        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera([FromBody] CreateCarreraDto carrera)
        {
            var carreraToSend = await _service.PostCarrera(carrera);
            return Ok(carreraToSend);
        }

        [HttpPut]
        public async Task<ActionResult<Carrera>> PutCarreraAsync(UpdateCarreraDto carreraDto)
        {
            var dbCarrera = await _service.PutCarrera(carreraDto);

            return Ok(dbCarrera);
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<Carrera>> DeleteCarreraAsync(int id)
        {
            var carrera = await _service.DeleteCarrera(id);
            if (carrera == null)
            {
                return NotFound(carrera);
            }
            return Ok(carrera);
        }

    }
}
