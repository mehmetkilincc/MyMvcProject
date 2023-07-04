using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.DataAccess.Data;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfWriterRepository : RepositoryBase<Writer, MyMvcProjectContext>, IWriterRepository
    {
        MyMvcProjectContext _context = new MyMvcProjectContext();
        public Writer GetByMailAddress(string mail)
        {          
            return _context.Writers.Where(p=>p.WriterMail == mail).FirstOrDefault();
        }
    }
}
