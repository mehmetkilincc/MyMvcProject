using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfImageFileDal : EntityRepositoryBase<ImageFile,MyMvcProjectContext> , IImageFileDal
    {
    }
}
