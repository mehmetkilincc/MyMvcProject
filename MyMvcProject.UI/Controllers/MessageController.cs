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
        private readonly IMessageService _messageService = new MessageService(new EfMessageRepository());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string receiverMail = (string)Session["WriterMail"];
            var inboxMessages = _messageService.GetAllInbox(receiverMail);
            return View(inboxMessages);
        }

        public ActionResult SendBox()
        {
            string senderMail = (string)Session["WriterMail"];
            var sendboxMessages = _messageService.GetAllSendbox(senderMail);
            return View(sendboxMessages);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var message = _messageService.GetById(id);
            return View(message);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var message = _messageService.GetById(id);
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
                _messageService.Add(message);
                return RedirectToAction("SendBox", "Message");
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