using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccess.EntityFramewok;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.UI.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
         CommentsManager cm = new CommentsManager(new EfCommentsRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.TGetList(id);
            return View(values); 
        }

    }
}