using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Concrete.EntityFramework;

namespace MyMvcProject.UI.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contents = _contentService.GetAllByHeadingId(id);
            return View(contents);
        }
    }
}