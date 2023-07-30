using Pizzapan.DataAccessLayer.Abstract;
using Pizzapan.DataAccessLayer.Repositories;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
    }
}
