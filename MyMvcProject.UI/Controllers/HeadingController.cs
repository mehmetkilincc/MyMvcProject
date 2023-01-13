using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.Business.ValidationRules.FluentValidation;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.UI.Controllers
{
    public class HeadingController : Controller
    {
        private readonly IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private readonly ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        private readonly IWriterService _writerService = new WriterManager(new EfWriterDal());
        private HeadingValidator HeadingValidator = new HeadingValidator();
        public ActionResult Index()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> category = (from x in _categoryService.GetAll()
                                             select new SelectListItem()
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            List<SelectListItem> writer = (from x in _writerService.GetAll()
                                           select new SelectListItem()
                                           {
                                               Text = x.WriterName + " " + x.WriterSurname,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.writer = writer;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            ValidationResult result = HeadingValidator.Validate(heading);
            if (result.IsValid)
            {
                _headingService.Add(heading);
                return RedirectToAction("Index", "Heading");
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

        public ActionResult ContentByHeading()
        {

            return View();
        }

    }
}