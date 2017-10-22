using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevJobs.Common.Constants;
using DevJobs.Services.Contracts;
using DevJobs.Web.Contracts.Identity;
using DevJobs.Web.Models;
using Microsoft.AspNet.Identity;
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
        private readonly IApplicationUserManager userManager;
       
        public ProfileController(IAdService adService, IApplicationUserManager userManager, IMapper mapper)
        {
            this.adService = adService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult MyCandidatures()
        {
            var userId = User.Identity.GetUserId();
            var user = this.userManager.Users.Where(x => x.Id == userId).SingleOrDefault();
            var ads = user.Adverts.Select(x => this.mapper.Map<AdViewModel>(x)).ToList();

            var viewModel = new MainViewModel()
            {
                Ads = ads,
            };

            return this.View(viewModel);
        }
    }
}