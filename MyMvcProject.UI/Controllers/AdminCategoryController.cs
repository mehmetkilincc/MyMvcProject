﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using MyMvcProject.Business.Concrete;
using MyMvcProject.Business.ValidationRules.FluentValidation;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.UI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        // GET: AdminCategory
        public ActionResult Index()
        {
            var categoryList = categoryManager.GetAll();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("Index", "AdminCategory");
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

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = categoryManager.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                categoryManager.Update(category);
                return RedirectToAction("Index", "AdminCategory");
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

        public ActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.Delete(category);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}