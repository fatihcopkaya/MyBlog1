using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyBlog.UI.Models;

namespace MyBlog.UI.Controllers;

public class HomeController : Controller
{
    
    
    
    public IActionResult Index()
    {
        return View();
    }

    

    
}
