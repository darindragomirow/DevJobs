using DevJobs.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Models.Models
{
    public class Level : DataModel
    {
        public string Type { get; set; }

        public ICollection<Advert> Adverts { get; set; }
    }
}
