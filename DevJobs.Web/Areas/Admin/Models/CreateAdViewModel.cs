using AutoMapper;
using DevJobs.Models;
using DevJobs.Models.Models;
using DevJobs.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevJobs.Web.Areas.Admin.Models
{
    public class CreateAdViewModel : IMapFrom<Advert>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        //public string CompanyName { get; set; }

        public Company Company { get; set; }

        //public string City { get; set; }

        public City City { get; set; }

        public int PreViews { get; set; }

        //public string Technology { get; set; }

        public Technology Technology { get; set; }

        //public string Level { get; set; }

        public Level Level { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Advert, CreateAdViewModel>()
                .ForMember(adViewModel => adViewModel.Title, cfg => cfg.MapFrom(advert => advert.Title))
                .ForMember(adViewModel => adViewModel.Description, cfg => cfg.MapFrom(advert => advert.Description))
                .ForMember(adViewModel => adViewModel.Company, cfg => cfg.MapFrom(advert => advert.Company))
                .ForMember(adViewModel => adViewModel.Technology, cfg => cfg.MapFrom(advert => advert.Technology))
                .ForMember(adViewModel => adViewModel.Level, cfg => cfg.MapFrom(advert => advert.Level))
                .ForMember(adViewModel => adViewModel.City, cfg => cfg.MapFrom(advert => advert.City));
        }
    }
}
