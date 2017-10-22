using AutoMapper;
using DevJobs.Models;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Contracts.Identity;
using DevJobs.Web.Controllers;
using DevJobs.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevJobs.Web.Tests.Controllers
{
    [TestFixture]
    public class AdsControllerTests
    {
        [Test]
        public void GetAll_ShouldReturnViewResult()
        {
            //Arrange
            var adServiceMock = new Mock<IAdService>();
            //var cityServiceMock = new Mock<ICityService>();
            var mapper = new Mock<IMapper>();
            var userManager = new Mock<IApplicationUserManager>();
            int page = 1;

            var controller = new AdsController
                (
                adServiceMock.Object,
                userManager.Object,
                mapper.Object
                );

            //Act
            var result = controller.GetAll(page) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetDetails_ShouldReturnViewResult()
        {
            //Arrange
            var adServiceMock = new Mock<IAdService>();
            var userManager = new Mock<IApplicationUserManager>();
            var mapper = new Mock<IMapper>();
            Guid id = Guid.NewGuid();

            var controller = new AdsController
                (
                adServiceMock.Object,
                userManager.Object,
                mapper.Object
                );

            //Act
            var result = controller.GetDetails(id) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetFiltered_ShouldReturnViewResult()
        {
            //Arrange
            var adServiceMock = new Mock<IAdService>();
            var userManager = new Mock<IApplicationUserManager>();
            var mapper = new Mock<IMapper>();
            Guid id = Guid.NewGuid();

            var controller = new AdsController
                (
                adServiceMock.Object,
                userManager.Object,
                mapper.Object
                );

            //Act
            var result = controller.GetFiltered() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAll_ShouldReturnAllAsignAllAdsReturnedFromService()
        {
            // Arrange
            var ads = new Advert[]
            {
                new Advert { Id = Guid.NewGuid() },
                new Advert { Id = Guid.NewGuid() }
            };
            int page = 1;

            var adServiceMock = new Mock<IAdService>();
            adServiceMock
                .Setup(x => x.GetAll())
                .Returns(ads.AsQueryable());



            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<AdViewModel>(It.IsAny<Advert>()))
                .Returns<Advert>(x => new AdViewModel { Id = x.Id });

            var userManager = new Mock<IApplicationUserManager>();

            var controller = new AdsController(
                adServiceMock.Object,
                userManager.Object,
                mapperMock.Object);

            // Act
            var result = ((controller.GetAll(page) as ViewResult).Model as IEnumerable<AdViewModel>);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(result.First().Id, ads.First().Id);
        }
    }
}
