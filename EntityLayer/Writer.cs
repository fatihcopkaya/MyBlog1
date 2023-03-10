using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Writer 
    {
       
        public int WriterId { get; set; }
		public string WriterName { get; set; }
		public string? WriterAbout { get; set; }
		public string WriterImage { get; set; }
		public string WriterMail { get; set; }
		public string WriterPassword { get; set; }
		public bool WriterStatus { get; set; }
		public virtual int RoleId { get; set; }
        public virtual Role Roles { get; set; }


       
    }
}