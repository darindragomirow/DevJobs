using AutoMapper;
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
        private readonly IMapper mapper;

        
        public HomeController(IAdService adService, IMapper mapper)
        {
            this.adService = adService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //var ads = this.adService
            //    .GetAll()
            //    .Select(x => this.mapper.Map<AdViewModel>(x))
            //    .ToList();

            //var viewModel = new MainViewModel()
            //{
            //    Ads = ads,
            //};

            //return View(viewModel);

            return View();
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
    }
}