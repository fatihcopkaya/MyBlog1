using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CommentsManager : ICommentsService
    {
        ICommetsDal _commentsDal;
        public CommentsManager(ICommetsDal commentsDal)
        {
            _commentsDal = commentsDal;
        }

        public IEnumerable<Comments> GetCommentListWithBlogId()
        {
           return _commentsDal.GetListAll();
        }

        public void TAdd(Comments t)
        {
            _commentsDal.Insert(t);
        }

        public void TDelete(Comments t)
        {
             _commentsDal.Delete(t);
        }

        public Comments TGetById(int id)
        {
            return _commentsDal.GetById(id);
        }

        public List<Comments> TGetList(int id)
        {
            return _commentsDal.GetListAll(x => x.BlogId == id);
        }

        public List<Comments> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comments t)
        {
            throw new NotImplementedException();
        }
    }
}