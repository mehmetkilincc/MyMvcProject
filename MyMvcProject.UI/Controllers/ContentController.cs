using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.DataAccess.Data;

namespace MyMvcProject.UI.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var searchContents = _contentService.GetAllbyContent(text);
                return View(searchContents);
            }
            var contents = _contentService.GetAll();
            return View(contents);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contents = _contentService.GetAllByHeadingId(id);
            return View(contents);
        }
        public ActionResult Report()
        {
            var contents = _contentService.GetAll();
            return View(contents);
        }
    }
}