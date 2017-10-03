using DevJobs.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevJobs.Models;
using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;

namespace DevJobs.Services
{
    public class Service : IService
    {
        private readonly IEfRepository<Advert> adsRepo;
        private readonly ISaveContext context;

        public Service(IEfRepository<Advert> adsRepo, ISaveContext context)
        {
            this.adsRepo = adsRepo;
            this.context = context;
        }

        public IQueryable<Advert> GetAll()
        {
            return this.adsRepo.All;
        }

        public void Update(Advert ad)
        {
            this.adsRepo.Update(ad);
            this.context.Commit();
        }
    }
}
