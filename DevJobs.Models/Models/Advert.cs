using DevJobs.Models.Abstracts;
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

        public virtual Location Location { get; set; }

        public virtual Company Company { get; set; }

    }
}
