using DevJobs.Models.Abstracts;

namespace DevJobs.Models
{
    public class Location : DataModel
    { 
        public virtual Country Country { get; set; }

        public virtual City City { get; set; }
    }
}