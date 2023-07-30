using Microsoft.AspNetCore.Http;

namespace Pizzapan.PresentationLayer.Models
{
    public class ImageFileViewModel
    {
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
