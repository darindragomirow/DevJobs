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
    public class AdvertViewModelTests
    {
        [Test]
        public void AdvertModel_ShouldSetCorrectProperties()
        {
            //Arrange
            var id = Guid.NewGuid();
            var title = "test";
            var description = "test";
            var createdOn = DateTime.Now;
            var companyName = "Telerik";
            var city = "Sofiq";
            var technology = ".NET";
            var level = "Junior";
            var preViews = 5;
            var mapperConfiguration = new MapperConfigurationExpression();
            var adModel = new AdViewModel()
            {
                Id = id,
                Title = title,
                Description = description,
                CreatedOn = createdOn,
                CompanyName = companyName,
                City = city,
                Technology = technology,
                Level = level,
                PreViews = preViews,
            };
            adModel.CreateMappings(mapperConfiguration);
            //Act & Assert
            Assert.AreEqual(adModel.Id, id);
            Assert.AreEqual(adModel.Title, title);
            Assert.AreEqual(adModel.Description, description);
            Assert.AreEqual(adModel.CreatedOn, createdOn);
            Assert.AreEqual(adModel.CompanyName, companyName);
            Assert.AreEqual(adModel.City, city);
            Assert.AreEqual(adModel.Technology, technology);
            Assert.AreEqual(adModel.Level, level);
            Assert.AreEqual(adModel.PreViews, preViews);

        }
    }
}
