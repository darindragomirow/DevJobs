using DevJobs.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevJobs.Models
{
    public class Company : DataModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public Guid ? CountryId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        
        public Guid ? CityId { get; set; }
    }
}