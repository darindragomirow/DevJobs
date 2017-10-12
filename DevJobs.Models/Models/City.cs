using DevJobs.Models.Abstracts;
using System.Collections;
using System.Collections.Generic;

namespace DevJobs.Models
{
    public class City : DataModel
    {
        public string Name { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}