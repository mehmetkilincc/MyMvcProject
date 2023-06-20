using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyMvcProject.UI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            MyMvcProjectContext context = new MyMvcProjectContext();
            var adminIfo = context.Admins.FirstOrDefault(p=>p.UserName == admin.UserName && p.Password == admin.Password);
            if (adminIfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminIfo.UserName, false);
                Session["Username"]=adminIfo.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}