using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.Business.ValidationRules.FluentValidation;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.UI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService = new CategoryService(new EfCategoryRepository());
        private readonly IHeadingService _headingService = new HeadingService(new EfHeadingRepository());
        public ActionResult Index()
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
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                _categoryService.Update(category);
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult Headings(int id)
        {
            var headings = _headingService.GetAllByCategoryId(id);
            return View(headings);
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetById(id);
            _categoryService.Delete(category);
            return RedirectToAction("Index", "AdminCategory");
        }

        public ActionResult Report()
        {
            var categoryReport = _categoryService.GetAll();
            return View(categoryReport);
        }

    }
}