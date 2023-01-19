using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public void TAdd(User t)
        {
            _userdal.Insert(t);
        }

        public void TDelete(User t)
        {
            throw new NotImplementedException();
        }

        public User TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(User t)
        {
            throw new NotImplementedException();
        }
    }
}