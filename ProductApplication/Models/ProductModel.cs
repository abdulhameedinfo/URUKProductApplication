using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models
{
    public class ProductModel
    {
        [Key]
        public Guid ID { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Double? Price{ get; set; }

        public int? Color{ get; set; }

        public int? Size { get; set; }
        public int? InStock { get; set; }
    }
}
