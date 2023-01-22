using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Abstract
{
    public interface IBlogDal :IGenericDal<Blog>
    {
               List<Blog> GetListWithCategory();
               List<Blog> GetListWithCategoryByWriter(int id);
               Task<string> AddUploadAsync(IFormFile file, string FolderName);
               


    }
}