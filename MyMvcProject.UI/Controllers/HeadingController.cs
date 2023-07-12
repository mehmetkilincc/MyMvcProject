 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;
        private HeadingValidator HeadingValidator = new HeadingValidator();

        public HeadingController(IHeadingService headingService, ICategoryService categoryService, IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public ActionResult Index()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem()
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            List<SelectListItem> writers = (from x in _writerService.GetAll()
                                            select new SelectListItem()
                                            {
                                                Text = x.WriterName + " " + x.WriterSurname,
                                                Value = x.WriterId.ToString()
                                            }).ToList();
            ViewBag.writers = writers;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            ValidationResult result = HeadingValidator.Validate(heading);
            if (result.IsValid)
            {
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                heading.HeadingStatus = true;
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

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            var heading = _headingService.GetById(id);
            return View(heading);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("Index", "Heading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = _headingService.GetById(id);

            heading.HeadingStatus = heading.HeadingStatus ? false:true;
            _headingService.Delete(heading);
            return RedirectToAction("Index", "Heading");
        }
        public ActionResult Report()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }
    }
}