using Microsoft.EntityFrameworkCore;

namespace ProyectoJorgeManzano.Models
{
    public class Contexto : DbContext
    {
        public DbSet<EquipoModelo> Equipos { get; set; }
        public DbSet<CompeticionModelo> Competiciones { get; set; }
        public DbSet<PaisModelo> Paises { get; set; }
        public DbSet<CompeticionEquipoModelo> CompeticionesEquipos { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }        
    }
}
