using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.Business.ValidationRules.FluentValidation;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.UI.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService = new WriterService(new EfWriterRepository());
        public ActionResult Index()
        {
            var writers = _writerService.GetAll();
            return View(writers);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                _writerService.Add(writer);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writer = _writerService.GetById(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                _writerService.Update(writer);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                   ModelState.AddModelError(error.PropertyName,error.ErrorMessage); 
                }
            }
            return View();
        }
    }
}