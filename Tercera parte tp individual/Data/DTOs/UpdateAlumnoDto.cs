namespace Tercera_parte_tp_individual.Data.DTOs
{
    public class UpdateAlumnoDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string legajo { get; set; }
        public int CarreraId { get; set; }
    }
}
