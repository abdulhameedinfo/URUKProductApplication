using ProductApplication.Models;

namespace ProductApplication.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
