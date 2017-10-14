using DevJobs.Models.Abstracts;
using DevJobs.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevJobs.Models
{
    public class Country : DataModel, IDataModel
    {
        public Country()
        {
            this.Adverts = new HashSet<Advert>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}