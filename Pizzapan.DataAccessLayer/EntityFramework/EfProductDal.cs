using Microsoft.EntityFrameworkCore;
using Pizzapan.DataAccessLayer.Abstract;
using Pizzapan.DataAccessLayer.Concrete;
using Pizzapan.DataAccessLayer.Repositories;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductsWithCategory()
        {
            using var context = new Context();
            return context.Products.Include(x => x.Category).ToList();
        }
    }
}
