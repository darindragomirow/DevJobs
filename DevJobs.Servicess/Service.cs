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
    public class Service : IService,IDisposable
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Service() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
