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
        public ActionResult MyContent(string sessionInfo)
        {
            MyMvcProjectContext context = new MyMvcProjectContext();
            sessionInfo = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(p => p.WriterMail == sessionInfo).Select(y => y.WriterId).FirstOrDefault();
            var contents = _contentService.GetAllByWriterId(writerId);
            return View(contents);
        }
    }
}