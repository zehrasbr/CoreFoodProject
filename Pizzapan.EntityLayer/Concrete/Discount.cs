using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.EntityLayer.Concrete
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int DiscountCount { get; set; }
    }
}
