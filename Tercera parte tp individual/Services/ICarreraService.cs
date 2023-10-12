using Microsoft.AspNetCore.Mvc;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;

namespace Tercera_parte_tp_individual.Services
{
    public interface ICarreraService
    {
        Task<ActionResult<ICollection<GetCarreraDto>>> GetCarreras();
        Task<ActionResult<GetCarreraDto>> GetCarrera(int id);
        Task<ActionResult<Carrera>> PostCarrera([FromBody] CreateCarreraDto carrera);
        Task<ActionResult<Carrera>> PutCarrera(UpdateCarreraDto carreraDto);
        Task<ActionResult<Carrera>> DeleteCarrera(int id);
        
    }
}
