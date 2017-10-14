using DevJobs.Models.Abstracts;
using DevJobs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Models.Models
{
    public class Technology : DataModel, IDataModel
    {
        public Technology()
        {
            this.Adverts = new HashSet<Advert>();
        }
        [Required]
        public string Type { get; set; }

        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
