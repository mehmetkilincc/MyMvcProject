

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfWriterDal:EntityRepositoryBase<Writer,MyMvcProjectContext>,IWriterDal
    {
    }
}
