using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Repositories;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace DataAccess.EntityFramewok
{
    public class EfDocumentRepository : GenericRepository<Blog>, IBlogDal
    {
        public readonly IHostingEnvironment _hostingEnvironment;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public EfDocumentRepository(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public EfDocumentRepository()
        {

        }
        public async Task<string> AddUploadAsync(IFormFile file, string FolderName)
        {
            if (file != null)
            {
                string Unique = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                string path = string.Concat(_hostingEnvironment.ContentRootPath + FolderName);
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
        public List<Blog> GetListWithCategory()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            throw new NotImplementedException();
        }
    }
}