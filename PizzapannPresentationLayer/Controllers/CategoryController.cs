using Microsoft.AspNetCore.Mvc;
using Pizzapan.BusinessLayer.Abstract;
using Pizzapan.EntityLayer.Concrete;

namespace PizzapannPresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values=_categoryService.TGetList();

            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            _categoryService.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteCategory() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCategory(Category p)
        {
            _categoryService.TDelete(p);
            return RedirectToAction("Index");
        }
    }
}
