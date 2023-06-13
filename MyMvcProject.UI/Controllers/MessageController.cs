using FluentValidation.Results;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.Business.Utilities;
using MyMvcProject.Business.ValidationRules.FluentValidation;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcProject.UI.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        // GET: Message
        public ActionResult Inbox()
        {
            var inboxMessages = messageManager.GetAllInbox();
            return View(inboxMessages);
        }

        public ActionResult SendBox()
        {
            var sendboxMessages = messageManager.GetAllSendbox();
            return View(sendboxMessages);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var message = messageManager.GetById(id);
            return View(message);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var message = messageManager.GetById(id);
            return View(message);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Message message)
        {
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Add(message);
                return RedirectToAction("Index", "Message");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}