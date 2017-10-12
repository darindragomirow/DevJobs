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
        public ActionResult GetDetails(Guid id)
        {
            var ads = this.adService
                .GetAll()
                .ProjectTo<AdViewModel>()
                .SingleOrDefault(x => x.Id == id);

            return View(ads);
        }

        [HttpGet]
        public ActionResult GetFiltered()
        {
            return View(new List<MainViewModel>());
        }

        [HttpPost]
        public ActionResult GetFiltered(string searchTerm)
        {
            string value = Request.Form["ChoiceList"].ToString();
            ViewBag.SelectedValue = value;
            //var ads = this.adService
            //    .GetAll()
            //    .ProjectTo<AdViewModel>()
            //    .Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()))
            //    .ToList();

            var ads = this.adService.GetFiltered(searchTerm)
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