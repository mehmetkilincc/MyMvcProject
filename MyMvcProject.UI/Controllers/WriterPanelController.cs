using FluentValidation.Results;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.Business.ValidationRules.FluentValidation;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.DataAccess.Data;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcProject.UI.Controllers
{
    public class WriterPanelController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;
        MyMvcProjectContext context = new MyMvcProjectContext();

        public WriterPanelController(IHeadingService headingService, ICategoryService categoryService, IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string sessionInfo = (string)Session["WriterMail"];
            id = context.Writers.Where(p => p.WriterMail == sessionInfo).Select(y => y.WriterId).FirstOrDefault();
            var writer = _writerService.GetById(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                _writerService.Update(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
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

        public ActionResult MyHeadings(string sessionInfo)
        {

            sessionInfo = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(p => p.WriterMail == sessionInfo).Select(y => y.WriterId).FirstOrDefault();
            var headings = _headingService.GetAllByWriterId(writerId);
            return View(headings);
        }
        public ActionResult AllHeading()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }

        public ActionResult NewHeading()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem()
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            var sessionInfo = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(p => p.WriterMail == sessionInfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerId;
            heading.HeadingStatus = true;
            _headingService.Add(heading);
            return RedirectToAction("MyHeadings", "WriterPanel");
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
            return RedirectToAction("MyHeadings", "WriterPanel");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = _headingService.GetById(id);

            heading.HeadingStatus = heading.HeadingStatus ? false : true;
            _headingService.Delete(heading);
            return RedirectToAction("MyHeadings", "WriterPanel");
        }
    }
}