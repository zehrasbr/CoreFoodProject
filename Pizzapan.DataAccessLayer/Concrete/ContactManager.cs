using Pizzapan.DataAccessLayer.Abstract;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.DataAccessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
        }
        public Contact TGetById(int id)
        {
            return _contactDal.GetByID(id);
        }
        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }
        public void TInsert(Contact t)
        {
            _contactDal.Insert(t);

        }
        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
