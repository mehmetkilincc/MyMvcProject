using MyMvcProject.Business.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcProject.UI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IWriterService _writerService;

        public WriterPanelContentController(IContentService contentService, IWriterService writerService)
        {
            _contentService = contentService; 
            _writerService = writerService;
        }

        [HttpGet]
        public ActionResult MyContent(string sessionInfo)
        {
            sessionInfo = (string)Session["WriterMail"];
            var writer = _writerService.GetByMailAddress(sessionInfo);
            var writerId = writer.WriterId;
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
            var writer = _writerService.GetByMailAddress(sessionInfo);
            var writerId = writer.WriterId;
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerId;
            content.Status = true;
            _contentService.Add(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ContentByHeading(int id)
        {
            var contents = _contentService.GetAllByHeadingId(id);
            return View(contents);
        }
    }
}