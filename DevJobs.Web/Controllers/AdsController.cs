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
using DevJobs.Common.Constants;
using Microsoft.AspNet.Identity;
using DevJobs.Web.Contracts.Identity;

namespace DevJobs.Web.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdService adService;
        private readonly IApplicationUserManager userManager;
        private readonly IMapper mapper;

        public AdsController(IAdService adService,IApplicationUserManager userManager, IMapper mapper)
        {
            this.adService = adService;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAll(int? page)
        {
            //var ads = this.adService
            //     .GetAll()
            //     .ProjectTo<AdViewModel>()
            //     .ToList();

            var ads = this.adService
                 .GetAll()
                 .OrderByDescending(x => x.CreatedOn.Value)
                 .ToList()
                 .Select(x => this.mapper.Map<AdViewModel>(x));

            var viewModel = new MainViewModel()
            {
                Ads = ads.ToList(),
            };

            int pageSize = Common.Constants.Constants.DefaultPageSize;
            int pageNumber = (page ?? 1);
            return this.View(ads.ToPagedList(pageNumber, pageSize));

            //return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetDetails(Guid id)
        {
            //var ad = this.adService
            //    .GetAll()
            //    .ProjectTo<AdViewModel>()
            //    .SingleOrDefault(x => x.Id == id);

            var ad = this.adService
                 .GetAll()
                 .ToList()
                 .Select(x => this.mapper.Map<AdViewModel>(x))
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
        public ActionResult GetFiltered(string searchTerm, int? page)
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

            int pageSize = Common.Constants.Constants.DefaultPageSize;
            int pageNumber = (page ?? 1);
            return View(ads.ToPagedList(pageNumber, pageSize));

            //return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Apply(AdViewModel model)
        {
            var advert = this.adService
                .GetAll()
                .Where(x => x.Id == model.Id)
                .SingleOrDefault();

            var userId = User.Identity.GetUserId();
            var user = this.userManager
                .Users
                .Where(x => x.Id == userId)
                .SingleOrDefault();

            //Adding the advert to user's adverts
            user.Adverts.Add(advert);

            this.adService.AddPreview(advert);

            return RedirectToAction("GetDetails", new { id = model.Id});
        }
    }
}