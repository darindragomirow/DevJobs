using DevJobs.Models.Abstracts;
using DevJobs.Models.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevJobs.Models
{
    public class City : DataModel, IDataModel
    {
        public City()
        {
            this.Adverts = new HashSet<Advert>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}