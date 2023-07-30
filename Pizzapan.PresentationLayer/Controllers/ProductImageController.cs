using Microsoft.AspNetCore.Mvc;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresentationLayer.Models;
using PizzaPan.BusinessLayer.Abstract;
using System;
using System.IO;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ImageFileViewModel model)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imageName = Guid.NewGuid()+extension;
            var saveLocation = resource + "/wwwroot/images/" + imageName;
            var stream = new FileStream(saveLocation, FileMode.Create);
            model.Image.CopyTo(stream);
            ProductImage productImage = new ProductImage();
            _productImageService.TInsert(productImage);
            return RedirectToAction("ImageList");
        }
    }
}
