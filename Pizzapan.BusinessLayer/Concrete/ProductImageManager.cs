using Pizzapan.DataAccessLayer.Abstract;
using Pizzapan.EntityLayer.Concrete;
using PizzaPan.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.BusinessLayer.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        public void TDelete(ProductImage entity)
        {
            _productImageDal.Delete(entity);
        }

        public ProductImage TGetByID(int id)
        {
           return _productImageDal.GetByID(id);
        }

        public List<ProductImage> TGetList()
        {
            return _productImageDal.GetList();
        }

        public void TInsert(ProductImage t)
        {
            _productImageDal.Insert(t);
        }

        public void TUpdate(ProductImage t)
        {
            _productImageDal.Update(t);
        }
    }
}
