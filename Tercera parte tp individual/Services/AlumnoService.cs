using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tercera_parte_tp_individual.Data;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;

namespace Tercera_parte_tp_individual.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly TP3Context _context;
        public AlumnoService(TP3Context context)
        {
            _context = context;
        }
        public async Task<ActionResult<Alumno>> DeleteAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
            }
            
            return (alumno);
        }

        public async Task<ActionResult<GetAlumnoDto>> GetAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            var alumnoDto = new GetAlumnoDto
            {
                id = alumno.id,
                nombre = alumno.nombre,
                apellido = alumno.apellido,
                legajo = alumno.legajo,
                CarreraId = alumno.CarreraId
            };
            return (alumnoDto);
        }

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
            return (alumnosDto);
        }

        public async Task<ActionResult<Alumno>> PostAlumno([FromBody] CreateAlumnoDto alumno)
        {
            var carrera = await _context.Carreras.FindAsync(alumno.CarreraId);
            Alumno alumnoToPost = new Alumno();
            if (carrera != null)
            {
                alumnoToPost.nombre = alumno.nombre;
                alumnoToPost.apellido = alumno.apellido;
                alumnoToPost.legajo = alumno.legajo;
                alumnoToPost.carrera = carrera;
                await _context.Alumnos.AddAsync(alumnoToPost);
                await _context.SaveChangesAsync();
            }
            return (alumnoToPost);
        }
    }
}
