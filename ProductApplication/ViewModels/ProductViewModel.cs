using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApplication.Models;

namespace ProductApplication.ViewModels
{
    public class ProductViewModel
    {
        public required ProductDTO product { get; set; }

        public IEnumerable<SelectListItem> ProductColorOptions { get; set; } = Enum.GetValues(typeof(ProductColor))
            .Cast<ProductColor>().Select(x => new SelectListItem()
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            });

        public IEnumerable<SelectListItem> ProductSizeOptions { get; set; } = Enum.GetValues(typeof(ProductSize))
            .Cast<ProductSize>().Select(x => new SelectListItem()
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            });
    }
}
