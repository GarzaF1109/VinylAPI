// .\Interfaces\IVinylRepository.cs
using vinyls.Entities;

namespace vinyls.Interfaces
{
    public interface IVinylRepository
    {
        IEnumerable<Vinyl> GetAllVinyls();
        Vinyl AddVinyl(Vinyl vinyl);
        
        // ¡NUEVO! Métodos para UPDATE y DELETE
        Vinyl? UpdateVinyl(int id, Vinyl updatedVinyl);
        bool DeleteVinyl(int id);
    }
}