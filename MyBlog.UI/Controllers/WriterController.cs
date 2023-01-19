using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramewok;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyBlog.UI.Controllers
{

    public class WriterController : Controller
    {
        
        WriterManager wm = new WriterManager(new EfWriterRepository());

       [Authorize(Roles = "writer")]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name; 
            MyConnectionDbContext c = new MyConnectionDbContext();          
            var writerName = c.Users.Where(x => x.Username == usermail).Select(y => y.Username).FirstOrDefault();
            ViewBag.wn = writerName;
            return View();
        }

         [Authorize(Roles = "writer")]
        public PartialViewResult WriterNavbarPartial()
        {
            var usermail = User.Identity.Name;
            MyConnectionDbContext c = new MyConnectionDbContext();
            var writerName = c.Users.Where(x => x.Username == usermail).Select(y => y.Username).FirstOrDefault();
            ViewBag.wn = writerName;
            return PartialView();
        }
         [Authorize(Roles = "writer")]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }


    }
}