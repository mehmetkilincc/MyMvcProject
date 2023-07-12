using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly IWriterService _writerService;
        private readonly ICategoryService _categoryService;
        private readonly IContentService _contentService;

        public HomeController(IHeadingService headingService, IWriterService writerService, ICategoryService categoryService, IContentService contentService)
        {
            _headingService = headingService;
            _writerService = writerService;
            _categoryService = categoryService;
            _contentService = contentService;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var categories = _categoryService.GetAll();
            var headings = _headingService.GetAll();
            var writer = _writerService.GetAll();
            var contents = _contentService.GetAll();

            ViewBag.CategoryCount = categories.Count();
            ViewBag.HeadingCount = headings.Count();
            ViewBag.WriterCount = writer.Count();
            ViewBag.ContentCount = contents.Count();
            return View();
        }
    }
}