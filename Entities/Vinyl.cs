// .\Entities\Vinyl.cs
using System.ComponentModel.DataAnnotations;

namespace vinyls.Entities
{
    public class Vinyl
    {
        public int ID { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Artist { get; set; } // <--- Changed to nullable string
        public int? Year { get; set; }    // <--- Changed to nullable int
    }
}