using Microsoft.AspNetCore.Mvc;

namespace PizzapanPresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
