using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICommentsService : IGenericService<Comments>
    {
        public List<Comments> TGetList(int id);
        public IEnumerable<Comments> GetCommentListWithBlogId();
        
        
    }
}