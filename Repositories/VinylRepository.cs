// .\Repositories\VinylRepository.cs
using vinyls.Entities;
using vinyls.Interfaces; // Asegúrate de incluir tu namespace de interfaces

namespace vinyls.Repositories
{
    public class VinylRepository : IVinylRepository
    {
        // La lista "dura" de vinilos
        private readonly List<Vinyl> _vinyls;

        public VinylRepository()
        {
            // Inicializa la lista con al menos 3 vinilos
            _vinyls = new List<Vinyl>
            {
                new Vinyl { ID = 1, Name = "Abbey Road", Artist = "The Beatles", Year = 1969 },
                new Vinyl { ID = 2, Name = "Dark Side Of The Moon", Artist = "Pink Floyd", Year = 1973 },
                new Vinyl { ID = 3, Name = "Thriller", Artist = "Michael Jackson", Year = 1982 }
            };
        }

        // Implementa el método de la interfaz para devolver los vinilos
        public IEnumerable<Vinyl> GetAllVinyls()
        {
            return _vinyls;
        }
    }
}