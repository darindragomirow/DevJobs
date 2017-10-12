using DevJobs.Models.Abstracts;
using System.Collections.Generic;

namespace DevJobs.Models
{
    public class Country : DataModel
    {
        public string Name { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}