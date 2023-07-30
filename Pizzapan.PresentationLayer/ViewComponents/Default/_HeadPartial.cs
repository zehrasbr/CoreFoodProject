using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresentationLayer.ViewComponents.Default
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
