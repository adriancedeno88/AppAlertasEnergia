using AppAlertasEnergia.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAlertasEnergia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Alerta> Alerta { get; set; }

        public DbSet<Canton> Canton { get; set; }

        public DbSet<Cronograma> Cronograma { get; set; }
        public DbSet<Provincia> Provincia { get; set; }

        public DbSet<Sector> Sector { get; set; }

        public DbSet<Sesion> Sesion { get; set; }

        public DbSet<Usuario> Usuario { get; set; }


    }
}
