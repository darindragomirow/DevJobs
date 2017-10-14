using AutoMapper;
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