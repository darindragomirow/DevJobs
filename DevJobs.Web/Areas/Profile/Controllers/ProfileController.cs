using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevJobs.Common.Constants;
using DevJobs.Services.Contracts;
using DevJobs.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevJobs.Web.Areas.Profile.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAdService adService;
        private readonly IMapper mapper;
       
        public ProfileController(IAdService adService, IMapper mapper)
        {
            this.adService = adService;
            this.mapper = mapper;
        }

        // GET: Profile/Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyCandidatures()
        {
            var ads = this.adService
                 .GetAll()
                 .ProjectTo<AdViewModel>()
                 .Take(Constants.TopAdsCount)
                 .ToList();

            var viewModel = new MainViewModel()
            {
                Ads = ads,
            };

            return this.View(viewModel);
        }

        public ActionResult Apply(int id, string username)
        {

            return RedirectToAction("MyCandidatures");
        }
    }
}