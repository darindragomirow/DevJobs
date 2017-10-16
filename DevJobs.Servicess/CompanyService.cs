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
    public class CompanyService : IService, ICompanyService
    {
        private readonly IEfRepository<Company> companyRepo;
        private readonly ISaveContext context;

        public CompanyService(IEfRepository<Company> companyRepo, ISaveContext context)
        {
            this.companyRepo = companyRepo;
            this.context = context;
        }

        public IQueryable<Company> GetAll()
        {
            return this.companyRepo.All;
        }


        public IQueryable<Company> GetAllAndDeleted()
        {
            return this.companyRepo.AllAndDeleted;
        }



        public void Add(Company company)
        {
            this.companyRepo.Add(company);
            context.Commit();
        }

        public void Update(Company company)
        {
            this.companyRepo.Update(company);
            this.context.Commit();
        }
    }
}
