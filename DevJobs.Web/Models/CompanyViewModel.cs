using DevJobs.Models;
using DevJobs.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace DevJobs.Web.Models
{
    public class CompanyViewModel : IMapFrom<Company>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Company, CompanyViewModel>()
                .ForMember(companyViewModel => companyViewModel.Name, cfg => cfg.MapFrom(company => company.Name))
                .ForMember(companyViewModel => companyViewModel.Description, cfg => cfg.MapFrom(company => company.Description))
                .ForMember(companyViewModel => companyViewModel.Rating, cfg => cfg.MapFrom(company => company.Rating));
        }
    }
}