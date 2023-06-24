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
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentService = new ContentManager(new EfContentDal());

        [HttpGet]
        public ActionResult MyContent()
        {
            var contents = _contentService.GetAllByWriter();
            return View(contents);
        }
    }
}