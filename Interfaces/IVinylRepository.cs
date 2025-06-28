// .\Interfaces\IVinylRepository.cs

using vinyls.Entities; // <--- ADD THIS LINE

namespace vinyls.Interfaces
{
    public interface IVinylRepository
    {
        // Define un método para obtener todos los vinilos
        IEnumerable<Vinyl> GetAllVinyls();
    }
}