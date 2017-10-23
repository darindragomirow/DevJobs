using DevJobs.Models;
using DevJobs.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace DevJobs.Web.Models
{
    public class AdViewModel : IMapFrom<Advert>, IHaveCustomMappings
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:d MMMM-yyyy hh:mm}")]
        public DateTime CreatedOn { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Technology { get; set; }

        public string Level { get; set; }

        public int PreViews { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Advert, AdViewModel>()
                .ForMember(adViewModel => adViewModel.Title, cfg => cfg.MapFrom(advert => advert.Title))
                .ForMember(adViewModel => adViewModel.Description, cfg => cfg.MapFrom(advert => advert.Description))
                .ForMember(adViewModel => adViewModel.Technology, cfg => cfg.MapFrom(advert => advert.Technology.Type))
                .ForMember(adViewModel => adViewModel.Level, cfg => cfg.MapFrom(advert => advert.Level.Type))
                .ForMember(adViewModel => adViewModel.CompanyName, cfg => cfg.MapFrom(advert => advert.Company.Name))
                .ForMember(adViewModel => adViewModel.City, cfg => cfg.MapFrom(advert => advert.City.Name));
        }
    }
}