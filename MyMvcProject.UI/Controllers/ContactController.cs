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
        // GET: Contact
        ContactManager contactManager= new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var contacts = contactManager.GetAll();
            return View(contacts);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contact = contactManager.GetById(id);
            return View(contact);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}