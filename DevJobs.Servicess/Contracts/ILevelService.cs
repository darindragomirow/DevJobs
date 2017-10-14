using DevJobs.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Servicess.Contracts
{
    public interface ILevelService
    {
        IQueryable<Level> GetAll();
        void Add(Level newLevel);
    }
}
