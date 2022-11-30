using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();

            return View(categories);
        }

        public ActionResult GetCategoryList()
        {
            var categoryList = _categoryService.GetAll();
            return View(categoryList);
        }


        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction("GetCategoryList","Category");
        }
    }
}