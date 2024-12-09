using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Context;
using ProductApplication.Models;
using ProductApplication.Repository.Interface;
using System.Drawing;

namespace ProductApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext productContext;
        public ProductRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        void IProductRepository.CreateProduct(ProductDTO productDTO)
        {
            var product = new ProductModel()
            {
                Name = productDTO.Name,
                Color = productDTO.Color,
                Description = productDTO.Description,
                InStock = productDTO.InStock,
                Price = productDTO.Price,
                Size = productDTO.Size
            };

            productContext.Products.Add(product);
            productContext.SaveChanges();
        }

        void IProductRepository.DeleteProductById(Guid id)
        {
            var product = productContext.Products.FirstOrDefault(x => x.ID == id);

            if (product != null)
            {
                productContext.Products.Remove(product);
                productContext.SaveChanges();
            }
        }

        ProductDTO? IProductRepository.GetProductById(Guid id)
        {
            var product = productContext.Products.SingleOrDefault(x => x.ID == id);

            if (product == null)
                return null;

            var productDTO = new ProductDTO()
                {
                    ID = product.ID,
                    Name = product.Name,
                    Color = product.Color,
                    Description = product.Description,
                    InStock = product.InStock,
                    Price = product.Price,
                    Size = product.Size
                };
            return productDTO;
        }

        IEnumerable<ProductDTO> IProductRepository.GetProducts()
        {
            return productContext.Products.ToList().ConvertAll(x => new ProductDTO()
            {
                ID = x.ID,
                Name = x.Name,
                Color = x.Color,
                Description = x.Description,
                InStock = x.InStock,
                Price = x.Price,
                Size = x.Size
            });
        }

        void IProductRepository.UpdateProductById(ProductDTO productDTO)
        {
            var product = productContext.Products.FirstOrDefault(x => x.ID == productDTO.ID);

            if (product != null)
            {
                product.ID = productDTO.ID;
                product.Name = productDTO.Name;
                product.Color = productDTO.Color;
                product.Description = productDTO.Description;
                product.InStock = productDTO.InStock;
                product.Price = productDTO.Price;
                product.Size = productDTO.Size;

                productContext.Products.Update(product);
                productContext.SaveChanges();
            }

        }
    }
}
