using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevJobs.Common.Constants;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevJobs.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IAdService adService;
        private readonly IMapper mapper;

        public CompaniesController(ICompanyService companyService,IAdService adService, IMapper mapper)
        {
            this.companyService = companyService;
            this.adService = adService;
            this.mapper = mapper;
        }

        // GET: Companies
        public ActionResult GetAll(int? page)
        {
            //var companies = this.companyService
            //     .GetAll()
            //     .ProjectTo<CompanyViewModel>()
            //     .ToList();

            var companies = this.companyService
                .GetAll()
                .ToList()
                .Select(x => this.mapper.Map<CompanyViewModel>(x));

            var viewModel = new MainViewModel()
            {
                Companies = companies.ToList(),
            };

            int pageSize = Constants.DefaultPageSize;
            int pageNumber = (page ?? 1);
            return View(companies.ToPagedList(pageNumber, pageSize));

            //return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetDetails(Guid id)
        {
            var company = this.companyService
                .GetAll()
                .ToList()
                .Select(x => this.mapper.Map<CompanyViewModel>(x))
                .SingleOrDefault(x => x.Id == id);

            var ads = this.adService
                .GetAll()
                .ToList()
                .Where(x => x.CompanyId.Equals(id))
                .Select(x => this.mapper.Map<AdViewModel>(x));

            var model = new CompanyAdsViewModel()
            {
                Ads = ads.ToList(),
                Company = company,
            };

            return View(model);
        }
    }
}