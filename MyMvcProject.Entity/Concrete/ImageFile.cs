﻿using MyMvcProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Entity.Concrete
{
    public class ImageFile : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string ImageName { get; set; }
        [StringLength(250)]
        public string ImagePath { get; set; }
    }
}
