using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.UI.ViewComponents.RegisterCity
{
    public class RegisterCityList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}