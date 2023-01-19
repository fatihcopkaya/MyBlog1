using BusinessLayer.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramewok;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.UI.Controllers
{

    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        MyConnectionDbContext c = new MyConnectionDbContext();




        public IActionResult Index()
        {
            var values = cm.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {

            cm.TAdd(category);
            return RedirectToAction("categoryList", "Category");


        }
        public IActionResult AddCategory()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult EditCategory(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = cm.TGetById(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category category, int id)
        {
            category.CategoryId = id;


            cm.TUpdate(category);


            return RedirectToAction("categoryList", "Category");


        }
        [Authorize(Roles = "admin")]
        public IActionResult categoryList()
        {
            IEnumerable<Category> catreogrtList = c.Categories;

            return View(catreogrtList);

        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = cm.TGetById(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var obj = cm.TGetById(id);
            if (obj == null)
            {
                return NotFound();
            }
            cm.TDelete(obj);
            TempData["Success"] = "Category Deleted successfuly";

            return RedirectToAction("categoryList", "Category");
        }



    }
}