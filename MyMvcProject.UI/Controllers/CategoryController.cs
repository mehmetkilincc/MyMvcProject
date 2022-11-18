using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Concrete;

namespace MyMvcProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService = new CategoryManager(new CategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();

            return View(categories);
        }
    }
}