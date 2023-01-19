using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        MyConnectionDbContext c = new MyConnectionDbContext();
        public void Delete(T t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }

        public void Update(T t)
        {
            c.Entry(t).State = EntityState.Detached;
            c.Set<T>().Update(t);
            c.SaveChanges();

        }
    }
}