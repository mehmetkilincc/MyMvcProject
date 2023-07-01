using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.DataAccess.Data;
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
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin admin)
        {
            MyMvcProjectContext context = new MyMvcProjectContext();
            var adminIfo = context.Admins.FirstOrDefault(p => p.UserName == admin.UserName && p.Password == admin.Password);
            if (adminIfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminIfo.UserName, false);
                Session["Username"] = adminIfo.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Admin", "Login");
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

            MyMvcProjectContext context = new MyMvcProjectContext();
            var writerInfo = context.Writers.FirstOrDefault(p => p.WriterMail == writer.WriterMail && p.WriterPassword == writer.WriterPassword);
            if (writerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerInfo.WriterMail, false);
                Session["WriterMail"] = writerInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("Writer", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Main");
        }
    }
}