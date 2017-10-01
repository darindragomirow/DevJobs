using DevJobs.Models.Abstracts;

namespace DevJobs.Models
{
    public class Company : DataModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public virtual Location Location { get; set; }
    }
}