using Microsoft.AspNetCore.Mvc;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;

namespace Tercera_parte_tp_individual.Services
{
    public interface IAlumnoService
    {
        Task<ActionResult<ICollection<GetAlumnoDto>>> GetAlumnos();
        Task<ActionResult<GetAlumnoDto>> GetAlumno(int id);
        Task<ActionResult<Alumno>> PostAlumno([FromBody] CreateAlumnoDto alumno);
        Task<ActionResult<Alumno>> DeleteAlumno(int id);
    }
}
