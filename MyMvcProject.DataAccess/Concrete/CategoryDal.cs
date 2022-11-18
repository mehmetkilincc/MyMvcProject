﻿using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.DataAccess.Concrete
{
    public class CategoryDal : EntityRepositoryBase<Category, MyMvcProjectContext>, ICategoryDal
    {
    }
}
