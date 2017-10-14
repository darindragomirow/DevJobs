using DevJobs.Servicess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevJobs.Models;
using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;

namespace DevJobs.Servicess
{
    public class CityService : IService, ICityService
    {
        private readonly IEfRepository<City> cityRepo;
        private readonly ISaveContext context;

        public CityService(IEfRepository<City> cityRepo, ISaveContext context)
        {
            this.cityRepo = cityRepo;
            this.context = context;
        }

        public IQueryable<City> GetAll()
        {
            return this.cityRepo.All;
        }

        public void Add(City city)
        {
            this.cityRepo.Add(city);
            context.Commit();
        }
        
        public void Update(City city)
        {
            this.cityRepo.Update(city);
            this.context.Commit();
        }
    }
}
