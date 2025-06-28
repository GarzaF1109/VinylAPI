// .\Controllers\VinylController.cs
using Microsoft.AspNetCore.Mvc;
using vinyls.Entities;
using vinyls.Interfaces;

namespace vinyls.Controllers
{
    [ApiController]
    [Route("api/vinyls")]
    public class VinylController : ControllerBase
    {
        private readonly IVinylRepository _vinylRepository;

        public VinylController(IVinylRepository vinylRepository)
        {
            _vinylRepository = vinylRepository;
        }

        [HttpGet]
        public IEnumerable<Vinyl> Get()
        {
            return _vinylRepository.GetAllVinyls();
        }

        // ¡NUEVO! Agrega el método POST
        [HttpPost]
        public IActionResult Post([FromBody] Vinyl newVinyl)
        {
            if (newVinyl == null)
            {
                return BadRequest("El vinilo no puede ser nulo.");
            }

            // Aquí puedes añadir validaciones adicionales si es necesario
            if (string.IsNullOrWhiteSpace(newVinyl.Name))
            {
                return BadRequest("El nombre del vinilo es obligatorio.");
            }

            var createdVinyl = _vinylRepository.AddVinyl(newVinyl);
            
            // Retorna un 201 CreatedAtAction con el vinilo recién creado
            // El primer parámetro es el nombre de la acción GET para este recurso (opcional pero buena práctica)
            // El segundo parámetro es un objeto anónimo con la ruta, en este caso el ID del nuevo vinilo
            return CreatedAtAction(nameof(Get), new { id = createdVinyl.ID }, createdVinyl);
        }
    }
}