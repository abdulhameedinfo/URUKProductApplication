
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models
{
    public class ProductDTO
    {
        public Guid ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public Double? Price { get; set; }

        [Required]
        public int? Color { get; set; }

        [Required]
        public int? Size { get; set; }

        [Required]
        public int? InStock { get; set; }
    }
}
