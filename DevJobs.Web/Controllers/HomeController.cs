﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        //private readonly  IMapper mapper;

        
        public HomeController(IAdService adService)
        {
            this.adService = adService;
            //this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var ads = this.adService
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .ToList()
                .Select(x => Mapper.Map<AdViewModel>(x));
                

            var viewModel = new MainViewModel()
            {
                Ads = ads.ToList(),
            };

            var list = new List<string>() { "Sofia", "Plovdiv", "Burgas" };
            ViewBag.ChoiceList = new SelectList(list);

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