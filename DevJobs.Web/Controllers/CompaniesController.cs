using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Models;
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
        private readonly IMapper mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.mapper = mapper;
        }

        // GET: Companies
        public ActionResult GetAll()
        {
            var companies = this.companyService
                 .GetAll()
                 .ProjectTo<CompanyViewModel>()
                 .ToList();

            var viewModel = new MainViewModel()
            {
                Companies = companies,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetDetails(Guid id)
        {
            var company = this.companyService
                .GetAll()
                .ProjectTo<CompanyViewModel>()
                .SingleOrDefault(x => x.Id == id);

            return View(company);
        }
    }
}