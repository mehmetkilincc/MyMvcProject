using MyMvcProject.Business.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyMvcProject.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IWriterLoginService _writerLoginService;
        private readonly IAdminLoginService _adminLoginService;

        public LoginController(IWriterLoginService writerLoginService, IAdminLoginService adminLoginService)
        {
            _writerLoginService = writerLoginService;
            _adminLoginService = adminLoginService;
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin admin)
        {
            var adminIfo = _adminLoginService.ValidateAdmin(admin.UserName,admin.Password) ;
            if (adminIfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminIfo.UserName, false);
                Session["Username"] = adminIfo.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is incorrect!");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Writer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Writer(Writer writer)
        {
            var writerInfo = _writerLoginService.ValidateWriter(writer.WriterMail,writer.WriterPassword);
            if (writerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerInfo.WriterMail, false);
                Session["WriterMail"] = writerInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is incorrect!");
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}