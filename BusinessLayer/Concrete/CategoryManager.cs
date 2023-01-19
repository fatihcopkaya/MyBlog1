using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramewok;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    { 
        ICategoryDal _categorydal;
        

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

    

        public void TAdd(Category t)
        {
          _categorydal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categorydal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _categorydal.GetById(id);
        }

        public List<Category> TGetList()
        {
            return _categorydal.GetListAll();
        }

        public void TUpdate(Category t)
        {
            _categorydal.Update(t);
        }

       
    }
}