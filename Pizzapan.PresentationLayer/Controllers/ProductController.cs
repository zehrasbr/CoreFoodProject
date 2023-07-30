using Microsoft.AspNetCore.Mvc;
using Pizzapan.EntityLayer.Concrete;
using PizzaPan.BusinessLayer.Abstract;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            //var values = _productService.TGetList();
            var values = _productService.TGetProductsWithCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.TInsert(product);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
