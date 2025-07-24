// .\Repositories\VinylRepository.cs
using vinyls.Entities;
using vinyls.Interfaces;
using vinyls.Data;

namespace vinyls.Repositories
{
    public class VinylRepository : IVinylRepository
    {
        private readonly VinylsDbContext _context;

        public VinylRepository(VinylsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vinyl> GetAllVinyls()
        {
            return _context.Vinyls.ToList();
        }

        // ¡NUEVO! Implementa el método para añadir un nuevo vinilo
        public Vinyl AddVinyl(Vinyl vinyl)
        {
            _context.Vinyls.Add(vinyl); // Agrega el vinilo al DbSet
            _context.SaveChanges();     // Guarda los cambios en la base de datos
            return vinyl;               // Retorna el vinilo con el ID generado (si aplica)
        }

        // ¡NUEVO! Implementa el método para actualizar un vinilo
        public Vinyl? UpdateVinyl(int id, Vinyl updatedVinyl)
        {
            var existingVinyl = _context.Vinyls.Find(id);
            
            if (existingVinyl == null)
            {
                return null;
            }

            // Actualiza las propiedades
            existingVinyl.Name = updatedVinyl.Name;
            existingVinyl.Artist = updatedVinyl.Artist;
            existingVinyl.Year = updatedVinyl.Year;

            _context.SaveChanges();
            return existingVinyl;
        }

        // ¡NUEVO! Implementa el método para eliminar un vinilo
        public bool DeleteVinyl(int id)
        {
            var vinyl = _context.Vinyls.Find(id);
            
            if (vinyl == null)
            {
                return false;
            }

            _context.Vinyls.Remove(vinyl);
            _context.SaveChanges();
            return true;
        }
    }
}