// .\Data\VinylsDbContext.cs
using Microsoft.EntityFrameworkCore;
using vinyls.Entities; // Asegúrate de importar tus entidades

namespace vinyls.Data
{
    public class VinylsDbContext : DbContext
    {
        // Constructor que acepta DbContextOptions para la configuración
        public VinylsDbContext(DbContextOptions<VinylsDbContext> options) : base(options)
        {
        }

        // DbSet representa una colección de entidades en la base de datos
        // Cada DbSet mapeará a una tabla en tu base de datos
        public DbSet<Vinyl> Vinyls { get; set; }

        // Opcional: Puedes configurar el mapeo de tus entidades aquí si lo necesitas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ejemplo de configuración de la clave primaria (ya se infiere por convención si se llama ID)
            modelBuilder.Entity<Vinyl>().HasKey(v => v.ID);

            // Puedes añadir datos iniciales (seeding) aquí si lo deseas
            modelBuilder.Entity<Vinyl>().HasData(
                new Vinyl { ID = 1, Name = "Abbey Road", Artist = "The Beatles", Year = 1969 },
                new Vinyl { ID = 2, Name = "Dark Side Of The Moon", Artist = "Pink Floyd", Year = 1973 },
                new Vinyl { ID = 3, Name = "Thriller", Artist = "Michael Jackson", Year = 1982 }
            );
        }
    }
}