using MyMvcProject.Business.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcProject.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public ActionResult Index()
        {
            var abouts = _aboutService.GetAll();
            return View(abouts);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _aboutService.Add(about);
            return RedirectToAction("Index", "About");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}