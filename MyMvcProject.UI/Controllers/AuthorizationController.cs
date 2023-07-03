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
    public class AuthorizationController : Controller
    {
        private readonly IAdminService _adminService = new AdminService(new EfAdminRepository());
        public ActionResult Index()
        {
            var admins = _adminService.GetAll();
            return View(admins);
        }
    }
}