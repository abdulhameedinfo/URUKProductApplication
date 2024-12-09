using ProductApplication.Models;

namespace ProductApplication.ViewModels
{
    public class ProductsViewModel
    {
        public required IEnumerable<ProductDTO> Products { get; set; }
    }
}
