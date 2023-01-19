using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyBlog.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        
        MyConnectionDbContext c = new MyConnectionDbContext();
        public IActionResult Index()
        {
            return View();
        }
         public IActionResult AdminNavbarPartial()
        {
            var adminmail = User.Identity.Name;
            var adminName = c.Admins.Where(x => x.Username == adminmail).Select(y => y.Username).FirstOrDefault();
            ViewBag.an = adminName;
            return PartialView();
        }

        
    }
}