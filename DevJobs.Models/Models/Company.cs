using DevJobs.Models.Abstracts;
using DevJobs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevJobs.Models
{
    public class Company : DataModel, IDataModel
    {
        public Company()
        {
            this.Adverts = new HashSet<Advert>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public Guid ? CountryId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        
        public Guid ? CityId { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}