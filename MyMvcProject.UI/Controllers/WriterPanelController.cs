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
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal()); 
        MyMvcProjectContext context = new MyMvcProjectContext();

        public ActionResult WriterProfile()
        {
            return View();
        }
 
        public ActionResult MyHeadings(string sessionInfo)
        {
            
            sessionInfo = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(p=>p.WriterMail == sessionInfo).Select(y=>y.WriterId).FirstOrDefault();
            var headings = _headingManager.GetAllByWriterId(writerId);
            return View(headings);
        }

        public ActionResult NewHeading()
        {
            List<SelectListItem> categories = (from x in _categoryManager.GetAll()
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
            _headingManager.Add(heading);
            return RedirectToAction("MyHeadings", "WriterPanel");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categories = (from x in _categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            var heading = _headingManager.GetById(id);
            return View(heading);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingManager.Update(heading);
            return RedirectToAction("MyHeadings", "WriterPanel");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = _headingManager.GetById(id);

            heading.HeadingStatus = heading.HeadingStatus ? false : true;
            _headingManager.Delete(heading);
            return RedirectToAction("MyHeadings", "WriterPanel");
        }
    }
}