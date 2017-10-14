using DevJobs.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Servicess.Contracts
{
    public interface ITechnologyService
    {
        IQueryable<Technology> GetAll();
        void Add(Technology newTechnology);
    }
}
