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
            return _contentDal.GetAll();
        }
        public List<Content> GetAllByWriterId(int id)
        {
            return _contentDal.GetAll(p=>p.WriterId == id);
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
            _contentDal.Add(content);
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
