using AutoMapper;
using AutoMapper.Configuration;
using DevJobs.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Web.Tests.Models
{
    [TestFixture]
    public class CompanyViewModelTests
    {
        [Test]
        public void CompanyViewModel_ShouldSetCorrectPropertiesWhenCreated()
        {
            //Arrange
            var id = Guid.NewGuid();
            var name = "test";
            var description = "test";
            var rating = 5;
            var mapperConfiguration = new MapperConfigurationExpression();


            var companyViewModel = new CompanyViewModel()
            {
                Id = id,
                Name = name,
                Description = description,
                Rating = rating,
            };
            companyViewModel.CreateMappings(mapperConfiguration);
            //Act & Assert
            Assert.AreEqual(companyViewModel.Id, id);
            Assert.AreEqual(companyViewModel.Name, name);
            Assert.AreEqual(companyViewModel.Description, description);
            Assert.AreEqual(companyViewModel.Rating, 5);
        }
    }
}
