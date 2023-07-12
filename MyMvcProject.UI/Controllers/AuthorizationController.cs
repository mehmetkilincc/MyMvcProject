using FluentValidation.Results;
using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
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
    [Authorize(Roles="Full Access")]
    public class AuthorizationController : Controller
    {
        private readonly IAdminService _adminService;

        public AuthorizationController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            var admins = _adminService.GetAll();
            return View(admins);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult result = adminValidator.Validate(admin);
            if (result.IsValid)
            {
                _adminService.Add(admin);
                return RedirectToAction("Index", "Authorization");
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

        public ActionResult Delete(int id)
        {
            var admin = _adminService.GetById(id);

            admin.Role = admin.Role == "Full Access" ? "Limited Access" : "Full Access";
            _adminService.Delete(admin);
            return RedirectToAction("Index", "Authorization");
        }
    }
}