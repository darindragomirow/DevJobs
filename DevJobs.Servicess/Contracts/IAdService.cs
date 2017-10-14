using DevJobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Services.Contracts
{
    public interface IAdService
    {
        IQueryable<Advert> GetAll();

        IQueryable<Advert> GetFiltered(string searchTerm, string location, string technology);

        void Add(Advert advert);

        void AddPreview(Advert advert);
    }
}
