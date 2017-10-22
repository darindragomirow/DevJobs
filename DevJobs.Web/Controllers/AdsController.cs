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

namespace DevJobs.Web.Controllers
{
    public class AdsController : Controller
    {
        private readonly IAdService adService;
        //private readonly ICityService cityService;
        private readonly IMapper mapper;

        public AdsController(IAdService adService,/* ICityService cityService,*/ IMapper mapper)
        {
            this.adService = adService;
            //this.cityService = cityService;
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
                 .ToList()
                 .Select(x => this.mapper.Map<AdViewModel>(x));

            var viewModel = new MainViewModel()
            {
                Ads = ads.ToList(),
            };

            int pageSize = Constants.DefaultPageSize;
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

            int pageSize = Constants.DefaultPageSize;
            int pageNumber = (page ?? 1);
            return View(ads.ToPagedList(pageNumber, pageSize));

            //return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Apply(Guid advertId, string userId)
        {
            return View();
        }
    }
}