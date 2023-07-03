using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvcProject.Business.Abstract;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.Business.Concrete
{
    public class HeadingService : IHeadingService
    {
        private readonly IHeadingRepository _headingRepository;

        public HeadingService(IHeadingRepository headingRepository)
        {
            _headingRepository = headingRepository;
        }

        public List<Heading> GetAll()
        {
            return _headingRepository.GetAll();
        }
        public List<Heading> GetAllByWriterId(int id)
        {
            return _headingRepository.GetAll(heading => heading.WriterId == id);
        }
        public List<Heading> GetAllByCategoryId(int id)
        {
            return _headingRepository.GetAll(heading => heading.CategoryId == id);
        }

        public Heading GetById(int id)
        {
            return _headingRepository.Get(x => x.HeadingId == id);
        }

        public void Add(Heading heading)
        {
            _headingRepository.Add(heading);
        }

        public void Update(Heading heading)
        {
            _headingRepository.Update(heading);
        }

        public void Delete(Heading heading)
        {
            _headingRepository.Update(heading);
        }
    }
}
