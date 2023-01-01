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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public void Add(Writer writer)
        {
             _writerDal.Add(writer);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }
    }
}
