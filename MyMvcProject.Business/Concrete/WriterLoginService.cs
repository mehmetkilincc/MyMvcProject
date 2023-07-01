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
    public class WriterLoginService : IWriterLoginService
    {
        private readonly IWriterRepository _writerRepository;

        public WriterLoginService(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public Writer ValidateWriter(string username, string password)
        {
            return _writerRepository.Get(p=> p.WriterMail == username && p.WriterPassword == password);
        }
    }
}
