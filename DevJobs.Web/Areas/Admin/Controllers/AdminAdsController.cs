using AutoMapper;
using DevJobs.Common.Constants;
using DevJobs.Models;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevJobs.Web.Areas.Admin.Controllers
{
    public class AdminAdsController : Controller
    {
        private readonly IAdService adService;
        private readonly ICityService cityService;

        public AdminAdsController(IAdService adService, ICityService cityService)
        {
            this.adService = adService;
            this.cityService = cityService;
        }

        // GET: Admin/AdminAds
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/AdminAds/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdminAds/Create
        [HttpGet]
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult CreateAd()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = Constants.AdminRole)]
        public ActionResult CreateAd(CreateAdViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                model.Id = Guid.NewGuid();

                var ad = Mapper.Map<CreateAdViewModel, Advert>(model);
                var city = this.cityService.GetAll().Where(x => x.Name.Equals("Burgas")).SingleOrDefault();
                ad.CityId = city.Id;

                this.adService.Add(ad);

                this.ModelState.Clear();
            }

            return this.View();
        }

        // GET: Admin/AdminAds/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdminAds/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminAds/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdminAds/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
