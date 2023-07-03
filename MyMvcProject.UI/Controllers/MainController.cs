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
    [AllowAnonymous]
    public class MainController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly IContentService _contentService;

        public MainController(IHeadingService headingService, IContentService contentService)
        {
            _headingService = headingService;
            _contentService = contentService;
        }

        public PartialViewResult Index(int id = 0)
        {
            var contents = _contentService.GetAllByHeadingId(id);
            return PartialView(contents);
        }
        public ActionResult Headings()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }
    }
}