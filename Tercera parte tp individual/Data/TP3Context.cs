using Microsoft.EntityFrameworkCore;
using Tercera_parte_tp_individual.Data.Modelos;

namespace Tercera_parte_tp_individual.Data
{
    public class TP3Context : DbContext
    {
        public TP3Context(DbContextOptions<TP3Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.UseIdentityAlwaysColumns();
        }

        internal Task<Carrera> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
    }
}
