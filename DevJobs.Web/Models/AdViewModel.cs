﻿using DevJobs.Models;
using DevJobs.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace DevJobs.Web.Models
{
    public class AdViewModel : IMapFrom<Advert>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Advert, AdViewModel>()
                .ForMember(adViewModel => adViewModel.Title, cfg => cfg.MapFrom(advert => advert.Title))
                .ForMember(adViewModel => adViewModel.Description, cfg => cfg.MapFrom(advert => advert.Description))
                .ForMember(adViewModel => adViewModel.City, cfg => cfg.MapFrom(advert => advert.City.Name));
        }
    }
}