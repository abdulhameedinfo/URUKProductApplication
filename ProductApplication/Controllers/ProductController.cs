using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;
using ProductApplication.Repository;
using ProductApplication.Repository.Interface;
using ProductApplication.ViewModels;

namespace ProductApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public IProductRepository _ProductRepository { get; }

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _ProductRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _ProductRepository.GetProducts();
            return View("Products", new ProductsViewModel() { Products = products});
        }

        [HttpPost]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteProduct()
        {
            return View();
        }
    }
}
