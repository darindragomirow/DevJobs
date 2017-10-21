using DevJobs.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevJobs.Models;
using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;
using DevJobs.Servicess.Contracts;

namespace DevJobs.Services
{
    public class AdService : IService, IAdService
    {
        private readonly IEfRepository<Advert> adsRepo;
        private readonly ISaveContext context;

        public AdService(IEfRepository<Advert> adsRepo, ISaveContext context)
        {
            this.adsRepo = adsRepo;
            this.context = context;
        }

        public IQueryable<Advert> GetAll()
        {
            return this.adsRepo.All;
        }

        public IQueryable<Advert> GetAllAndDeleted()
        {
            return this.adsRepo.AllAndDeleted;
        }

        public IQueryable<Advert> GetFiltered(string searchTerm, string location, string technology)
        {
            //var ads = this.adService
            //    .GetAll()
            //    .ProjectTo<AdViewModel>()
            //    .Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()))
            //    .ToList();
            if (searchTerm == "")
            {
                return this.adsRepo.All
                .Where(x => x.Technology.Type.Equals(technology)
                && x.City.Name.Equals(location));
            }
            return this.adsRepo.All
                .Where(x => x.Title.ToLower().Contains(searchTerm.ToLower())
                && x.Technology.Type.Equals(technology)
                && x.City.Name.Equals(location));
        }

        public void Add(Advert ad)
        {
            this.adsRepo.Add(ad);
            context.Commit();
        }

        public void AddPreview(Advert ad)
        {
            ad.PreViews++;
            context.Commit();
        }

        public void Update(Advert ad)
        {
            this.adsRepo.Update(ad);
            this.context.Commit();
        }
    }
}
