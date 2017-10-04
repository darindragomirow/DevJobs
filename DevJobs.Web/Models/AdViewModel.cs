using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevJobs.Web.Models
{
    public class AdViewModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CompanyName { get; set; }
    }
}