using System.Collections.Generic;

namespace DevJobs.Web.Models
{
    public class MainViewModel
    {
        public ICollection<AdViewModel> Ads { get; set; }
    }
}