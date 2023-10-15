using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tercera_parte_tp_individual.Data;
using Tercera_parte_tp_individual.Data.DTOs;
using Tercera_parte_tp_individual.Data.Modelos;

namespace Tercera_parte_tp_individual.Services
{
    public class CarreraService : ICarreraService
    {
        private readonly TP3Context _context;
        public CarreraService(TP3Context context)
        {
            _context = context;
        }
        public async Task<ActionResult<Carrera>> DeleteCarrera(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return (carrera);
            }
            _context.Carreras.Remove(carrera);
            await _context.SaveChangesAsync();
            return (carrera);
        }

        public async Task<ActionResult<GetCarreraDto>> GetCarrera(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {

                return (new GetCarreraDto());
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
                carreraDto.alumnos.Add(alumnoDto);
            };
            return carreraDto;
        }

        public async Task<ActionResult<ICollection<GetCarreraDto>>> GetCarreras()
        {
            var carreras = await _context.Carreras.ToListAsync();
            var carrerasDto = new List<GetCarreraDto>();
            if (carreras == null)
            {
                return carrerasDto;
            }
            var alumnos = await _context.Alumnos.ToListAsync();
            foreach (var carrera in carreras)
            {
                var carreraDto = new GetCarreraDto
                {
                    id = carrera.id,
                    nombre = carrera.nombre,
                    descripcion = carrera.descripcion,
                    alumnos = new List<GetAlumnoDto>()
                };
                if (alumnos != null)
                { 
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
                };
                carrerasDto.Add(carreraDto);
            }
            return carrerasDto;
        }

        public async Task<ActionResult<Carrera>> PostCarrera([FromBody] CreateCarreraDto carrera)
        {
            Carrera carreraToPost = new Carrera();
            carreraToPost.nombre = carrera.nombre;
            carreraToPost.descripcion = carrera.descripcion;
            await _context.Carreras.AddAsync(carreraToPost);
            await _context.SaveChangesAsync();
            var carreraToSend = await _context.Carreras.FindAsync(carreraToPost.id);
            return (carreraToSend);
        }

        public async Task<ActionResult<Carrera>> PutCarrera(UpdateCarreraDto carreraDto)
        {
            var dbCarrera = await _context.Carreras.FindAsync(carreraDto.id);
            if (dbCarrera == null)
            {
                return dbCarrera;
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
            return dbCarrera;
        }

       
    }
}
