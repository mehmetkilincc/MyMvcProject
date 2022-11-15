﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Entity
{
    public class Content
    {
        public int ContentId { get; set; }

        public string ContentText { get; set; }

        public DateTime ContentDate { get; set; }


        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

    }
}