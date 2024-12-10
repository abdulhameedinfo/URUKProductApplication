using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;
using ProductApplication.Repository;
using ProductApplication.Repository.Interface;
using ProductApplication.ViewModels;

namespace ProductApplication.Controllers
{
    [Route("Product")]
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
        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            var products = _ProductRepository.GetProducts();
            return View("Products", new ProductListViewModel() { Products = products });
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateProduct()
        {
            return View(new ProductViewModel() { product = new ProductDTO() });
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateProduct([Bind(Prefix = "product")] ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                _ProductRepository.CreateProduct(productDTO);
            }
            else
            {
                return View(new ProductViewModel() { product = productDTO });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Update/{id:guid}")]
        public IActionResult UpdateProduct(Guid id)
        {
            var productDTO = _ProductRepository.GetProductById(id);
            var updateProductModel = new ProductViewModel() { product = productDTO };
            return View("CreateProduct", updateProductModel);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateProduct([Bind(Prefix = "product")] ProductDTO productDTO)
        {
            _ProductRepository.UpdateProduct(productDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            _ProductRepository.DeleteProductById(id);
            return RedirectToAction("Index");
        }
    }
}
