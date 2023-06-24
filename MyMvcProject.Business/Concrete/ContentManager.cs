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
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<Content> GetAllByWriter()
        {
            return _contentDal.GetAll(p=>p.WriterId == 1);
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.GetAll(x => x.HeadingId == id);
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Content content)
        {
            throw new NotImplementedException();
        }

        public void Update(Content content)
        {
            throw new NotImplementedException();
        }

        public void Delete(Content content)
        {
            throw new NotImplementedException();
        }

       
    }
}
