using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresentationLayer.Models;
using System.Threading.Tasks;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
           public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = value.Name;
            model.Surname = value.Surname;
            model.Email = value.Email;
            model.City = value.City;
            model.UserName = value.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.City = model.City;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}
