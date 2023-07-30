using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresentationLayer.Models;
using System.Threading.Tasks;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class ConfirmEmailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ConfirmEmailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.username = TempData["Username"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.Username);
            if (user.ConfirmCode.ToString() == vm.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
