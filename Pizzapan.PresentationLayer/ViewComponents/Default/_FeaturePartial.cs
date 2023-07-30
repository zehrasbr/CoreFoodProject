using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.title1 = "Her Gün Pizza Yiyin";
            ViewBag.title2 = "Sevdiğiniz pizzaları paylaşın";
            return View();
        }
    }
}
