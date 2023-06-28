using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
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
        private readonly IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private readonly ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        MyMvcProjectContext context = new MyMvcProjectContext();

        public ActionResult WriterProfile()
        {
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