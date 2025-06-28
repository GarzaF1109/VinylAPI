// .\Interfaces\IVinylRepository.cs
using vinyls.Entities;

namespace vinyls.Interfaces
{
    public interface IVinylRepository
    {
        // Define un método para obtener todos los vinilos
        IEnumerable<Vinyl> GetAllVinyls();
        
        // ¡NUEVO! Define un método para añadir un nuevo vinilo
        Vinyl AddVinyl(Vinyl vinyl); 
    }
}