using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class User
    {
        
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public virtual int RoleId { get; set; }
        public virtual Role Roles { get; set; }
        public virtual List<Blog> Blog { get; set; }
    }
}