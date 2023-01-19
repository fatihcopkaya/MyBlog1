using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DataAccess.EntityFramewok
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public readonly Microsoft.Extensions.Hosting.IHostingEnvironment _hostingEnvironment;
        public EfBlogRepository(Microsoft.Extensions.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public EfBlogRepository()
        {
            
        }
        
        
        public List<Blog> GetListWithCategory()
        {
            using (var c = new MyConnectionDbContext())
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }


        }
        public void Update(Blog t)
        {
            using (var c = new MyConnectionDbContext())
            {
                c.Entry(t).State = EntityState.Detached;
                c.Set<Blog>().Update(t);
                c.SaveChanges();
            }

        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new MyConnectionDbContext())
            {
                return c.Blogs.Include(x => x.Category).Where(x => x.UserId == id).ToList();
            }
        }

        public async Task<string> AddUploadAsync(IFormFile file, string FolderName)
        {
            if (file != null)
            {
                string Unique = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                string path = string.Concat("/Users/fatihcopkayaoglu/Desktop/MyBlog/MyBlog.UI/wwwroot" + FolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filename = string.Concat(Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15), GetMimeTypes(file.ContentType));
                using var fileStream = new FileStream(Path.Combine(path, filename), FileMode.Create);
                await file.CopyToAsync(fileStream);
                return filename;
            }
            else
            {
                return file.FileName;
            }
        }
        private static string GetMimeTypes(string url)
        {
            string str = "";
            switch (url)
            {
                case "application/pdf":
                    str = ".pdf";
                    break;
                case "application/vnd.ms-excel":
                    str = ".xls";
                    break;
                case "application/vnd.ms-word":
                    str = ".doc";
                    break;
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                    str = ".pptx";
                    break;
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    str = ".xlsx";
                    break;
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    str = ".docx";
                    break;
                case "image/gif":
                    str = ".gif";
                    break;
                case "image/jpeg":
                    str = ".jpeg";
                    break;
                case "image/jpg":
                    str = ".jpg";
                    break;
                case "image/png":
                    str = ".png";
                    break;
                case "image/svg+xml":
                    str = ".svg";
                    break;
                case "image/webp":
                    str = ".webp";
                    break;
                case "text/plain":
                    str = ".txt";
                    break;
                case "video/mp4":
                    str = ".mp4";
                    break;
            }
            return str;
        }
    }
}