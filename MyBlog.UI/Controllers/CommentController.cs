using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramewok;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyBlog.UI.Controllers
{

    public class CommentController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        MyConnectionDbContext c = new MyConnectionDbContext();
        CommentsManager cm = new CommentsManager(new EfCommentsRepository());
     
        public IActionResult CommentListByBlog()
        {
            
            var values = cm.GetCommentListWithBlogId();
            return View(values);
        }
       public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = cm.TGetById(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var obj = cm.TGetById(id);
            if (obj == null)
            {
                return NotFound();
            }
            cm.TDelete(obj);
            TempData["Success"] = "Category Deleted successfuly";

            return RedirectToAction("CommentListByBlog", "Comment");
        }

    }
}