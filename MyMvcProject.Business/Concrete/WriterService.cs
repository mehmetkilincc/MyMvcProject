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
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        public WriterService(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }
        public List<Writer> GetAll()
        {
            return _writerRepository.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerRepository.Get(x => x.WriterId == id);
        }

        public void Add(Writer writer)
        {
             _writerRepository.Add(writer);
        }

        public void Update(Writer writer)
        {
            _writerRepository.Update(writer);
        }

        public void Delete(Writer writer)
        {
            _writerRepository.Delete(writer);
        }
    }
}
