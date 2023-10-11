using Tercera_parte_tp_individual.Data.Modelos;

namespace Tercera_parte_tp_individual.Data.DTOs
{
    public class GetCarreraDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public ICollection<GetAlumnoDto>? alumnos { get; set; }
    }
}
