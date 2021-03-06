﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevJobs.Common.Constants;
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
    public class HomeController : Controller
    {
        private readonly IAdService adService;
        private readonly IMapper mapper;
        private readonly ICompanyService companyService;

        public HomeController() { }

        public HomeController(IAdService adService,ICompanyService companyService, IMapper mapper)
        {
            this.adService = adService;
            this.companyService = companyService;
            this.mapper = mapper;
        }

        
        [HttpGet]
        public ActionResult Index()
        {
            var ads = this.adService
                .GetAll()
                .OrderByDescending(x=> x.CreatedOn.Value)
                .Take(Constants.TopAdsCount)
                .ToList()
                .Select(x => this.mapper.Map<AdViewModel>(x));

            var companies = this.companyService
                .GetAll()
                .OrderByDescending(x => x.Rating)
                .Take(Constants.TopCompaniesCount)
                .ToList()
                .Select(x => this.mapper.Map<CompanyViewModel>(x));

            var viewModel = new MainViewModel()
            {
                Ads = ads.ToList(),
                Companies = companies.ToList(),
            };

            var list = new List<string>() { "Sofiq", "Plovdiv", "Burgas", "Varna", "Haskovo" };
            ViewBag.ChoiceList = new SelectList(list);
            var technologyList = new List<string>() { "ASP.NET", "Java", "PHP", "Front-end", "SQL",
            "JavaScript", "Quality Assurance"};
            ViewBag.TechnologyList = new SelectList(technologyList);

            

            return View(viewModel);
        }

        [OutputCache(Duration = Constants.DefaultCacheDuration)]
        public PartialViewResult LatestAddedAdverts()
        {
            var ads = this.adService
               .GetAll()
               .OrderByDescending(x => x.CreatedOn.Value)
               .Take(Constants.TopAdsCount)
               .ToList()
               .Select(x => this.mapper.Map<AdViewModel>(x));
            var viewModel = new MainViewModel()
            {
                Ads = ads.ToList(),
            };

            return PartialView("_LatestAddedAdverts", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        //[HttpPost]
        //public ActionResult GetFiltered(string searchTerm)
        //{
        //    var ads = this.adService
        //        .GetAll()
        //        .ProjectTo<AdViewModel>()
        //        .Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()))
        //        .ToList();

        //    var viewModel = new MainViewModel()
        //    {
        //        Ads = ads,
        //    };

        //    return this.View(viewModel);
        //}
    }
}