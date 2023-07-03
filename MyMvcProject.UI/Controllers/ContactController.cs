using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.Business.ValidationRules.FluentValidation;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcProject.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contact = _contactService.GetById(id);
            return View(contact);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}