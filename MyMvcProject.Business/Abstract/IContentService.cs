using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetAllByWriterId(int id);
        List<Content> GetAllByHeadingId(int id);
        Content GetById(int id);
        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);
    }
}
