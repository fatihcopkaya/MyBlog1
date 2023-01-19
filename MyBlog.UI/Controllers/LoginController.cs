using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyBlog.UI.Controllers
{

    public class LoginController : Controller
    {

        MyConnectionDbContext c = new MyConnectionDbContext();


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User p)
        {
            var values = c.Users.FirstOrDefault(x => x.Username == p.Username && x.UserPassword == p.UserPassword);
            
            if (values != null)
            {
                if (values.RoleId == 1)
                {
                    var claims = new List<Claim>
                    {

                    new Claim(ClaimTypes.Name, values.Username),
                    new Claim(ClaimTypes.Role,"admin")
                    };
                    var useridentity = new ClaimsIdentity(claims, "user");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Admin");

                }
                else if(values.RoleId == 2)
                {
                    var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, values.Username),
                    new Claim(ClaimTypes.Role,"writer")
                };
                    var useridentity = new ClaimsIdentity(claims, "user");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Writer");

                }


            }
           

                return View();


        }






        
    }
    }