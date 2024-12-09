using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;

namespace ProductApplication.Models
{
    public class ProductDTO
    {
        public Guid ID { get; internal set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Double? Price{ get; set; }

        public string? Color{ get; set; }

        public int? Size { get; set; }
        public int? InStock { get; set; }
    }
}
