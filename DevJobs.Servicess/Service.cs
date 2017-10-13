using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Servicess
{
    public class Service : IService
    {
        private readonly IAdService adService;
        private readonly ICityService cityService;
        private readonly ICompanyService companyService;
        private readonly ITechnologyService technologyService;
        private readonly ILevelService levelService;

        public Service(IAdService adService, ICityService cityService,ICompanyService companyService,
            ITechnologyService technologyService, ILevelService levelService)
        {
            this.adService = adService;
            this.cityService = cityService;
            this.companyService = companyService;
            this.technologyService = technologyService;
            this.levelService = levelService;
        }

        public IAdService AdService { get => this.adService; }

        public ICityService CityService { get => this.cityService; }

        public ICompanyService CompanyService { get => this.companyService; }

        public ITechnologyService TechnologyService { get => this.technologyService; }

        public ILevelService LevelService { get => this.levelService; }

        
    }
}
