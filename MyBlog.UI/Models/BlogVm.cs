using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;

namespace MyBlog.UI.Models
{
    public class BlogVm
    {
        public virtual Blog Blog {get; set;} 
        public virtual List<Category> Categories{ get; set; }
    }
}