using System.ComponentModel.DataAnnotations;

namespace Pizzapan.PresentationLayer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage ="Email alanı boş geçilemez.")]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
