using AutoMapper;
using DevJobs.Common.Constants;
using DevJobs.Models;
using DevJobs.Models.Models;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevJobs.Web.Areas.Admin.Controllers
{
    public class AdminAdsController : Controller
    {
        private readonly IAdService adService;
        private readonly ICityService cityService;
        private readonly ICompanyService companyService;
        private readonly ITechnologyService technologyService;
        private readonly ILevelService levelService;
        private readonly IMapper mapper;

        public AdminAdsController(IAdService adService, ICityService cityService, ICompanyService companyService,
            ITechnologyService technologyService, ILevelService levelService, IMapper mapper)
        {
            this.adService = adService;
            this.cityService = cityService;
            this.companyService = companyService;
            this.technologyService = technologyService;
            this.levelService = levelService;
            this.mapper = mapper;
        }

        // GET: Admin/AdminAds
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/AdminAds/Create
        [HttpGet]
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult CreateAd()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult CreateAd(CreateAdViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                //Getting model properties
                model.CreatedOn = DateTime.Now;
                model.Id = Guid.NewGuid();

                var city = this.cityService.GetAll().Where(x => x.Name.Equals(model.City.Name)).SingleOrDefault();
                if (city != null)
                {
                    model.City = city;
                }
                else
                {
                    City newCity = new City() { Name = model.City.Name };
                    cityService.Add(newCity);
                    model.City = city;
                }

                var company = this.companyService.GetAll().Where(x => x.Name.Equals(model.Company.Name)).SingleOrDefault();
                if (company != null)
                {
                    model.Company = company;
                }
                else
                {
                    Company newCompany = new Company() { Name = model.Company.Name };
                    companyService.Add(newCompany);
                    model.Company = newCompany;
                }

                var technology = this.technologyService.GetAll().Where(x => x.Type.Equals(model.Technology.Type)).SingleOrDefault();
                if (technology != null)
                {
                    model.Technology = technology;
                }
                else
                {
                    Technology newTechnology = new Technology() { Type = model.Technology.Type };
                    technologyService.Add(newTechnology);
                    model.Technology = newTechnology;
                }


                var level = this.levelService.GetAll().Where(x => x.Type.Equals(model.Level.Type)).SingleOrDefault();
                if (level != null)
                {
                    model.Level = level;
                }
                else
                {
                    Level newLevel = new Level() { Type = model.Level.Type };
                    levelService.Add(newLevel);
                    model.Level = newLevel;
                }

                //Mapping ViewModel to DbModel
                //var ad = Mapper.Map<CreateAdViewModel, Advert>(model);
                var ad = this.mapper.Map<CreateAdViewModel, Advert>(model);

                //Adding the mapped object to the repository
                this.adService.Add(ad);

                this.ModelState.Clear();
            }

            return this.View();
        }
    }
}
