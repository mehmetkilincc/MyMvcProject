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
        private readonly IHeadingService _headingService = new HeadingManager(new EfHeadingDal());
        private readonly IContentService _contentService = new ContentManager(new EfContentDal());

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