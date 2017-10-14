using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Models.Contracts
{
    public interface IDataModel
    { 
        Guid Id { get; set; }

        bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? ModifiedOn { get; set; }
    }
}
