using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;
using DevJobs.Models.Models;
using DevJobs.Servicess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Servicess
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IEfRepository<Technology> technologyRepo;
        private readonly ISaveContext context;

        public TechnologyService(IEfRepository<Technology> technologyRepo, ISaveContext context)
        {
            this.technologyRepo = technologyRepo;
            this.context = context;
        }

        public IQueryable<Technology> GetAll()
        {
            return this.technologyRepo.All;
        }

        public void Update(Technology technology)
        {
            this.technologyRepo.Update(technology);
            this.context.Commit();
        }
    }
}
