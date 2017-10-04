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

        public HomeController(IAdService adService)
        {
            this.adService = adService;
        }

        public ActionResult Index()
        {
            var ads = this.adService
                .GetAll()
                .Select(x => new AdViewModel
                {
                    Title = x.Title,
                    Description = x.Description,
                    CompanyName = x.Company.Name,
                    CreatedOn = x.CreatedOn.Value
                })
                .ToList();

            var viewModel = new MainViewModel()
            {
                Ads = ads,
            };

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
    }
}