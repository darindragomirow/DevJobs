using DevJobs.Common.Constants;
using DevJobs.Models.Abstracts;
using DevJobs.Models.Contracts;
using DevJobs.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Models
{
    public class Advert : DataModel, IDataModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int PreViews { get; set; }

        public int Salary { get; set; }

        
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public Guid ? CityId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public Guid ? CountryId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public Guid ? CompanyId { get; set; }

        [ForeignKey("TechnologyId")]
        public virtual Technology Technology { get; set; }

        public Guid ? TechnologyId { get; set; }

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        public Guid ? LevelId { get; set; }
    }
}
