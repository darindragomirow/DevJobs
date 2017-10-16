using DevJobs.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Services.Tests.Fakes
{
    public class DataModel_Fake : IDataModel, IDeletable, IAuditable
    {
        public Guid Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
