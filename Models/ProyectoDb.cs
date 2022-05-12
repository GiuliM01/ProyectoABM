using Microsoft.EntityFrameworkCore;

namespace ProyectoABM.Models
{
    public class ProyectoDb : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Facturacion> Facturaciones { get; set; }

        public ProyectoDb()
        {

        }

        public ProyectoDb( DbContextOptions<ProyectoDb> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>().HasIndex(x => x.Nombre);
        }

       

    }
}
