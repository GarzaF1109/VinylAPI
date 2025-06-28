// .\Controllers\VinylController.cs
using Microsoft.AspNetCore.Mvc;
using vinyls.Entities;
using vinyls.Interfaces; // ¡Importante! Añade esta directiva using

namespace vinyls.Controllers
{
    [ApiController]
    [Route("api/vinyls")]
    public class VinylController : ControllerBase
    {
        // Declara una variable privada para la interfaz del repositorio
        private readonly IVinylRepository _vinylRepository;

        // Constructor: Aquí es donde ASP.NET Core inyectará la implementación de IVinylRepository
        public VinylController(IVinylRepository vinylRepository)
        {
            _vinylRepository = vinylRepository;
        }

        [HttpGet]
        public IEnumerable<Vinyl> Get()
        {
            // Ahora obtenemos los vinilos a través del repositorio inyectado
            return _vinylRepository.GetAllVinyls();
        }
    }
}