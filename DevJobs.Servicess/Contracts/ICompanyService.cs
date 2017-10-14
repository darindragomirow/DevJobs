using DevJobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Servicess.Contracts
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAll();
        void Add(Company newCompany);
    }
}
