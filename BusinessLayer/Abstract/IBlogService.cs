using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
                List<Blog> GetBlogListWithCategory();
                List<Blog> GetBlogListByWriter(int id);
                Task<string> AddUploadAsync(IFormFile file, string FolderName);
              
                


    }
}