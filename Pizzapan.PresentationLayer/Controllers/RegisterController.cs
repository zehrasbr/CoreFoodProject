using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using MimeKit;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresentationLayer.Models;
using System;
using System.Threading.Tasks;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);

            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName,
                ConfirmCode = x
            };
            if (model.Password == model.ConfirmPassword)
            {

                var result = await _userManager.CreateAsync(appUser, model.Password);


                if (result.Succeeded)
                {
                    #region 
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "zehraisbr@gmail.com");
                    mimeMessage.From.Add(mailboxAddressFrom);

                    MailboxAddress mailboxAdressTo = new MailboxAddress("User", model.Email);
                    mimeMessage.To.Add(mailboxAdressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Giriş yapabilmek için onaylama kodumuz:" + x;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Doğrulama Kodu";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("zehraisbr@gmail.com ", "awdcrpcyfsavjpjb");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    #endregion
                    ViewBag.username = TempData["Username"];
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
