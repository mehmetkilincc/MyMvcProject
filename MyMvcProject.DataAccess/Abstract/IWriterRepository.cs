using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.DataAccess.Abstract
{
    public interface IWriterRepository:IRepository<Writer>
    {
        Writer GetByMailAddress(string mail);
    }
}
