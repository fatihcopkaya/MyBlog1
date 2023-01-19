using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Repositories;
using EntityLayer;

namespace DataAccess.EntityFramewok
{
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        
    }
}