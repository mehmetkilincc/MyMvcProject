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
    public class GalleryController : Controller
    {
       private readonly IImageFileService _imageFileService = new ImageFileService(new EfImageFileRepository());
        // GET: Gallery
        public ActionResult Index()
        {
            var images = _imageFileService.GetAll();
            return View(images);
        }
    }
}