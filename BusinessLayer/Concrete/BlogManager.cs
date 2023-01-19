using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public Blog TGetById(int id)
        {
           return _blogDal.GetById(id);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogId == id);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetBlogListByWriter(int id) 
        {
            return _blogDal.GetListAll(x=>x.UserId==id); 

        }
        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public async Task<string> AddUploadAsync(IFormFile file, string FolderName)
        {
            return await _blogDal.AddUploadAsync(file, FolderName);
        }
    }
}