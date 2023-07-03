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
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;
        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public List<Content> GetAll()
        {
            return _contentRepository.GetAll();
        }
        public List<Content> GetAllByWriterId(int id)
        {
            return _contentRepository.GetAll(p=>p.WriterId == id);
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentRepository.GetAll(x => x.HeadingId == id);
        }
        public List<Content> GetAllbyContent(string text)
        {
            return _contentRepository.GetAll(x=> x.ContentText.Contains(text));
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Content content)
        {
            _contentRepository.Add(content);
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
