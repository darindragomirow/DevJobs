﻿using DevJobs.Models.Abstracts;
using DevJobs.Models.Contracts;
using DevJobs.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Models
{
    public class Advert : DataModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int PreViews { get; set; }

        public int Salary { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Company Company { get; set; }

        public virtual Technology Technology { get; set; }

        public virtual Level Level { get; set; }
    }
}
