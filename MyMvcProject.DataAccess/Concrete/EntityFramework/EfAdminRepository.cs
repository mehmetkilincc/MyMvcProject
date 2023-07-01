﻿using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.DataAccess.Data;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfAdminRepository : RepositoryBase<Admin,MyMvcProjectContext>, IAdminRepository
    {
    }
}
