
namespace Tercera_parte_tp_individual.Data.Modelos
{
    public class Carrera
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public ICollection<Alumno>? alumnos { get; set; }
    }
}
