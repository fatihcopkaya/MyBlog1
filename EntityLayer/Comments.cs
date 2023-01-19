using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
		public string? CommentUserName { get; set; }
		public string? CommentTitle { get; set; }
		public string? CommentContent { get; set; }
		public DateTime CommentDate { get; set; }
		public bool CommentStatus { get; set; }
        public virtual int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}