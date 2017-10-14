using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevJobs.Models;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DevJobs.Web.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdService adService;
        private readonly ICityService cityService;

        public AdsController(IAdService adService, ICityService cityService)
        {
            this.adService = adService;
            this.cityService = cityService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var ads = this.adService
                 .GetAll()
                 .ProjectTo<AdViewModel>()
                 .ToList();

            var viewModel = new MainViewModel()
            {
                Ads = ads,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetDetails(Guid id)
        {
            var ad = this.adService
                .GetAll()
                .ProjectTo<AdViewModel>()
                .SingleOrDefault(x => x.Id == id);

            var adSeen = this.adService
                .GetAll()
                .SingleOrDefault(x => x.Id == id);

            this.adService.AddPreview(adSeen);

            return View(ad);
        }

        [HttpGet]
        public ActionResult GetFiltered()
        {
            return View(new List<MainViewModel>());
        }

        [HttpPost]
        public ActionResult GetFiltered(string searchTerm)
        {
            string location = Request.Form["ChoiceList"].ToString();

            string technology = Request.Form["TechnologyList"].ToString();
            
            var ads = this.adService.GetFiltered(searchTerm, location, technology)
                .ProjectTo<AdViewModel>()
                .ToList();
                

            var viewModel = new MainViewModel()
            {
                Ads = ads,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult CreateAd()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateAd(AdViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                model.Id = Guid.NewGuid();
                
                var ad = Mapper.Map<AdViewModel, Advert>(model);
                var city = this.cityService.GetAll().Where(x => x.Name.Equals("Burgas")).SingleOrDefault();
                ad.CityId = city.Id;

                this.adService.Add(ad);

                this.ModelState.Clear();
            }

            return this.View();
        }
    }
}