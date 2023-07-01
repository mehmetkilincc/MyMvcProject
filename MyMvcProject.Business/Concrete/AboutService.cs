using MyMvcProject.Business.Abstract;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public void Add(About about)
        {
            _aboutRepository.Add(about);
        }

        public void Delete(About about)
        {
            _aboutRepository.Delete(about);
        }

        public List<About> GetAll()
        {
            return _aboutRepository.GetAll();
        }

        public About GetById(int id)
        {
           return _aboutRepository.Get(about => about.AboutId ==id);
        }

        public void Update(About about)
        {
            _aboutRepository.Update(about);
        }
    }
}
