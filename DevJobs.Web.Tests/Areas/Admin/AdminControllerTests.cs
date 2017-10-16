using AutoMapper;
using DevJobs.Models;
using DevJobs.Models.Models;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Areas.Admin.Controllers;
using DevJobs.Web.Areas.Admin.Models;
using DevJobs.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DevJobs.Web.Tests.Areas.Admin
{
    [TestFixture]
    public class AdminControllerTests
    {
        [Test]
        public void Index_ShouldReturnViewResult()
        {
            //Arrange
            var adServiceMock = new Mock<IAdService>();
            var cityServiceMock = new Mock<ICityService>();
            var companyServiceMock = new Mock<ICompanyService>();
            var technologyServiceMock = new Mock<ITechnologyService>();
            var levelServiceMock = new Mock<ILevelService>();
            var mapper = new Mock<IMapper>();

            var controller = new AdminAdsController
                (
                    adServiceMock.Object,
                    cityServiceMock.Object,
                    companyServiceMock.Object,
                    technologyServiceMock.Object,
                    levelServiceMock.Object,
                    mapper.Object
                );

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateAd_ShouldReturnViewResult()
        {
            //Arrange
            var adServiceMock = new Mock<IAdService>();
            var cityServiceMock = new Mock<ICityService>();
            var companyServiceMock = new Mock<ICompanyService>();
            var technologyServiceMock = new Mock<ITechnologyService>();
            var levelServiceMock = new Mock<ILevelService>();
            var mapper = new Mock<IMapper>();

            var controller = new AdminAdsController
                (
                    adServiceMock.Object,
                    cityServiceMock.Object,
                    companyServiceMock.Object,
                    technologyServiceMock.Object,
                    levelServiceMock.Object,
                    mapper.Object
                );

            //Act
            var result = controller.CreateAd() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateAd_ShouldCallAdServiceAdd()
        {
            // Arrange
            var adServiceMock = new Mock<IAdService>();
            var cityServiceMock = new Mock<ICityService>();
            var companyServiceMock = new Mock<ICompanyService>();
            var technologyServiceMock = new Mock<ITechnologyService>();
            var levelServiceMock = new Mock<ILevelService>();
            var mapper = new Mock<IMapper>();

            var controller = new AdminAdsController
                (
                    adServiceMock.Object,
                    cityServiceMock.Object,
                    companyServiceMock.Object,
                    technologyServiceMock.Object,
                    levelServiceMock.Object,
                    mapper.Object
                );

            var httpContext = new Mock<HttpContextBase>();
            //httpContext.Setup(x => x.User).Returns(principalMock.Object);
            var contextMock = new Mock<ControllerContext>();
            contextMock.Setup(x => x.HttpContext).Returns(httpContext.Object);


            var model = new CreateAdViewModel
            {
                Title = "title",
                Description = "info",
                City = new City() { Name = "Sofiq"},
                Company = new Company() { Name = "Telerik"},
                Level = new Level() { Type = "Junior"},
                Technology = new Technology() { Type = ".NET"}
            };

            // Act
            var result = controller.CreateAd(model);

            // Assert
            adServiceMock.Verify(x => x.Add(It.IsAny<Advert>()));
        }
    }
}
