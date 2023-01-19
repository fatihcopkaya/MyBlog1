using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramewok;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.UI.Models;

namespace MyBlog.UI.Controllers
{

        public class BlogController : Controller
    {

        CommentsManager com = new CommentsManager(new EfCommentsRepository());
        MyConnectionDbContext c = new MyConnectionDbContext();
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();

            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult BlogReadAll(Comments comments, int id, Blog p, string commentText)
        {

            // var comment = new Comments { CommentTitle = commentText, BlogId = id };
            CommentValidator cv = new CommentValidator();
            ValidationResult results = cv.Validate(comments);
            if (results.IsValid)
            {
                comments.BlogId = id;
                comments.CommentStatus = true;
                comments.CommentDate = comments.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                com.TAdd(comments);
                return RedirectToAction("BlogReadAll");


            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }


            }
            return View();
        }

        // public IActionResult BlogReadAll(int id)
        // {
        //     ViewBag.i = id;
        //     var values = bm.GetBlogById(id);

        //     return View(values);
        // }
        [Authorize(Roles = "writer")]
        public IActionResult BlogListByWriter()
        {
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.Username == usermail).Select(y => y.UserId).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(UserId);
            return View(values);
        }
        [Authorize(Roles = "writer")]
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            // List<Category> categoryvalues = (from x in cm.TGetList()
            //                                        select new SelectListItem
            //                                        {
            //                                            Text = x.CategoryName,
            //                                            Value = x.CategoryId.ToString()
            //                                        }).ToList();
            var news= new BlogVm()
            {
                Categories = cm.TGetList().ToList()
            };

            
            // ViewBag.cv = categoryvalues;
            return View(news);


        }
        [Authorize(Roles = "writer")]
        [HttpPost]
        public async Task<IActionResult> BlogAdd(BlogVm p, IFormFile file)
        {
            var Username = User.Identity.Name;
            var UserId = c.Users.Where(x => x.Username == Username).Select(y => y.UserId).FirstOrDefault();
            try
            {
                // p.Blog.Category = cm.TGetById(p.Blog.CategoryId);
                var FileCode = await bm.AddUploadAsync(file, "/file/Photos/");
                p.Blog.BlogImage = FileCode;
                p.Blog.BlogThumbnailImage = FileCode;
                p.Blog.UserId = UserId;
                p.Blog.BlogStatus = true;
                p.Blog.CreatedDateTime = p.Blog.CreatedDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                bm.TAdd(p.Blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            // BlogValidator bv = new BlogValidator();
            // ValidationResult results = bv.Validate(p.Blog);
            // if (results.IsValid)
            // {


            //     p.Blog.UserId = UserId;


            // }
            // else
            // {
            //     foreach (var item in results.Errors)
            //     {
            //         ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //     }


            // }




            return View();

        }


        [Authorize(Roles = "writer")]
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [Authorize(Roles = "writer")]
        public IActionResult EditBlog(int id)
        {
            // var values = bm.TGetById(id);

             var news= new BlogVm()
            {
                Categories = cm.TGetList().ToList(),
                Blog = bm.TGetById(id)
            };

            return View(news);

        }
        [Authorize(Roles = "writer")]
        [HttpPost]
        public async Task<IActionResult> EditBlog(BlogVm p, IFormFile file, int id)
        {
            p.Blog.BlogId = id;
            var usermail = User.Identity.Name;
            var UserId = c.Users.Where(x => x.Username == usermail).Select(y => y.UserId).FirstOrDefault();
            if (file != null)
            {
                var FileCode = await bm.AddUploadAsync(file, "/file/Photos/");
                p.Blog.BlogImage = FileCode;
                p.Blog.BlogThumbnailImage = FileCode;
                p.Blog.UserId = UserId;
                p.Blog.BlogStatus = true;
                p.Blog.CreatedDateTime = p.Blog.CreatedDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                bm.TUpdate(p.Blog);
                return RedirectToAction("BlogListByWriter");

            }
            else
            {
                p.Blog.BlogThumbnailImage = p.Blog.BlogThumbnailImage;
            }

            return View();

            // var blogValue = bm.TGetById(p.BlogId);
            // p.UserId = UserId;

            // p.CreatedDateTime = DateTime.Parse(blogValue.CreatedDateTime.ToShortDateString());

            // p.BlogStatus = true;

            // bm.TUpdate(p);


            // return RedirectToAction("BlogListByWriter");


        }
        public PartialViewResult SliderPartial()
        {

            return PartialView();
        }




    }
}
