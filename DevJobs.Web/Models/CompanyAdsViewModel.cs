using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevJobs.Web.Models
{
    public class CompanyAdsViewModel
    {
        public ICollection<AdViewModel> Ads { get; set; }

        public CompanyViewModel Company { get; set; }
    }
}