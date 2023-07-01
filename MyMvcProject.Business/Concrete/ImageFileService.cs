using MyMvcProject.Business.Abstract;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.Concrete
{
    public class ImageFileService : IImageFileService
    {
        private readonly IImageFileRepository _imageFileRepository;

        public ImageFileService(IImageFileRepository imageFileRepository)
        {
            _imageFileRepository = imageFileRepository;
        }

        public List<ImageFile> GetAll()
        {
            return _imageFileRepository.GetAll();
        }
    }
}
