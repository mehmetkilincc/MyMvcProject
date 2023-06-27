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
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }
        public List<Heading> GetAllByWriterId(int id)
        {
            return _headingDal.GetAll(heading => heading.WriterId == id);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
