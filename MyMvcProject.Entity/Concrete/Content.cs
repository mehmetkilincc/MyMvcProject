﻿using MyMvcProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Entity.Concrete
{
    public class Content : IEntity
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentText { get; set; }

        public DateTime ContentDate { get; set; }

        public bool Status { get; set; }
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }

    }
}
