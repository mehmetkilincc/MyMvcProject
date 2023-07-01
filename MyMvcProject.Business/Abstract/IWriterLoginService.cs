using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.Abstract
{
    public interface IWriterLoginService
    {
        Writer ValidateWriter(string username, string password);
    }
}
