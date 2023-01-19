using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EntityLayer
{
    public class Blog

    {
        [Key]
        public int BlogId { get; set; }

        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
        public string? BlogThumbnailImage { get; set; }
        public string? BlogImage { get; set; }
        public bool BlogStatus { get; set; }
        public DateTime CreatedDateTime { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<Comments> Comment { get; set; }
    }
}