using ProductApplication.Models;

namespace ProductApplication.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO? GetProductById(Guid id);

        void CreateProduct(ProductDTO productDTO);
        void UpdateProductById(ProductDTO productDTO);
        void DeleteProductById(Guid id);


    }
}
