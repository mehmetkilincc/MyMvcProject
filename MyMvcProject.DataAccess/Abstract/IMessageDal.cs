﻿using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.DataAccess.Abstract
{
    public interface IMessageDal:IEntityRepository<Message>
    {
    }
}
