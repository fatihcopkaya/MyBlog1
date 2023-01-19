using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccess.EntityFramewok;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.UI.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.TGetList();
            return View(values);
        }
    }
}