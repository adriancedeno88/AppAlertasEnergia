using AppAlertasEnergia.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAlertasEnergia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alerta>()
                .HasOne(c => c.cronograma)
                .WithMany(p => p.Alertas)
                .HasForeignKey(c => c.idsector)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Canton>()
                .HasOne(c=> c.provincia)
                .WithMany(p=> p.cantones)
                .HasForeignKey(c=>c.idProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sector>()
                .HasOne(c => c.Canton)
                .WithMany(s => s.Sectores)
                .HasForeignKey(c => c.idcanton)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sector>()
                .HasOne(c => c.Cronograma)
                .WithOne(s => s.Sector)
                .HasForeignKey<Cronograma>(c => c.idSector)
                .OnDelete(DeleteBehavior.Restrict);
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
