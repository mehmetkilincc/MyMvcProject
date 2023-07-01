using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.DataAccess.Data;
using MyMvcProject.Entity.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcProject.UI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentService = new ContentService(new EfContentRepository());
        MyMvcProjectContext _context = new MyMvcProjectContext();

        [HttpGet]
        public ActionResult MyContent(string sessionInfo)
        {
            sessionInfo = (string)Session["WriterMail"];
            var writerId = _context.Writers.Where(p => p.WriterMail == sessionInfo).Select(y => y.WriterId).FirstOrDefault();
            var contents = _contentService.GetAllByWriterId(writerId);
            return View(contents);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string sessionInfo = (string)Session["WriterMail"];
            var writerId = _context.Writers.Where(p => p.WriterMail == sessionInfo).Select(y => y.WriterId).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerId;
            content.Status = true;
            _contentService.Add(content);
            return RedirectToAction("MyContent");
        }
    }
}