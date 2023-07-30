using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
