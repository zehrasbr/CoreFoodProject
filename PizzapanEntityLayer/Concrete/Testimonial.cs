using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.EntityLayer.Concrete
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string CustomerTitle { get; set; }
        public string Comment { get; set; }
        public string ImageURL { get; set; }
    }
}
