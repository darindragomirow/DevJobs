using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevJobs.Common.Constants;
using DevJobs.Models;
using DevJobs.Services.Contracts;
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
        //private readonly IMapper mapper;


        public HomeController(IAdService adService)
        {
            this.adService = adService;
            //this.mapper = mapper;
        }

        
        [HttpGet]
        [OutputCache(Duration = Constants.DefaultCacheDuration)]
        public ActionResult Index()
        {
            var ads = this.adService
                .GetAll()
                .OrderByDescending(x=> x.CreatedOn.Value)
                .Take(Constants.TopAdsCount)
                .ToList()
                .Select(x => Mapper.Map<AdViewModel>(x));
                

            var viewModel = new MainViewModel()
            {
                Ads = ads.ToList(),
            };

            var list = new List<string>() { "Sofia", "Plovdiv", "Burgas" };
            ViewBag.ChoiceList = new SelectList(list);
            var technologyList = new List<string>() { "ASP.NET", "Java EE", "Android", "Front-end", "MSSQL" };
            ViewBag.TechnologyList = new SelectList(technologyList);

            return View(viewModel);
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
        
        [HttpPost]
        public ActionResult GetFiltered(string searchTerm)
        {
            var ads = this.adService
                .GetAll()
                .ProjectTo<AdViewModel>()
                .Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()))
                .ToList();

            var viewModel = new MainViewModel()
            {
                Ads = ads,
            };

            return this.View(viewModel);
        }
    }
}