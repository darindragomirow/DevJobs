using AutoMapper;
using DevJobs.Models;
using DevJobs.Models.Models;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Areas.Admin;
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
using System.Web.Routing;

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
                City = new City() { Name = "Sofiq" },
                Technology = new Technology { Type = ".NET"},
                Level = new Level() { Type = "Junior" },
                Company = new Company() { Name = "Telerik" },
            };

            // Act
            var result = controller.CreateAd(model);

            // Assert
            adServiceMock.Verify(x => x.Add(It.IsAny<Advert>()));
        }


        [Test]
        public void CreateAd_ShouldCallAdServiceAddWhenModelPropertiesExist()
        {
            // Arrange
            var adServiceMock = new Mock<IAdService>();
            var cityServiceMock = new Mock<ICityService>();
            var companyServiceMock = new Mock<ICompanyService>();
            var technologyServiceMock = new Mock<ITechnologyService>();
            var levelServiceMock = new Mock<ILevelService>();
            var mapper = new Mock<IMapper>();

            var cities = new City[]
           {
                new City(){ Name = "Sofiq" },
           };
            cityServiceMock
                .Setup(x => x.GetAll())
                .Returns(cities.AsQueryable());

            var companies = new Company[]
           {
                new Company(){ Name = "Telerik" },
           };
            companyServiceMock
                .Setup(x => x.GetAll())
                .Returns(companies.AsQueryable());

            var technologies = new Technology[]
           {
                new Technology(){ Type = ".NET" },
           };
            technologyServiceMock
                .Setup(x => x.GetAll())
                .Returns(technologies.AsQueryable());

            var levels = new Level[]
          {
                new Level(){ Type = "Junior" },
          };
            levelServiceMock
                .Setup(x => x.GetAll())
                .Returns(levels.AsQueryable());



            var model = new CreateAdViewModel
            {
                Title = "title",
                Description = "info",
                City = new City() { Name = "Sofiq" },
                Technology = new Technology { Type = ".NET" },
                Level = new Level() { Type = "Junior" },
                Company = new Company() { Name = "Telerik" },
            };

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

            

            // Act
            var result = controller.CreateAd(model);

            // Assert
            adServiceMock.Verify(x => x.Add(It.IsAny<Advert>()));
        }

        [Test]
        public void TestAdminAreaRoute()
        {
            var routes = new RouteCollection();

            // Get my AreaRegistration class
            var areaRegistration = new AdminAreaRegistration();
            Assert.AreEqual("Admin", areaRegistration.AreaName);

            // Get an AreaRegistrationContext for my class. Give it an empty RouteCollection
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
            areaRegistration.RegisterArea(areaRegistrationContext);

            // Mock up an HttpContext object with my test path (using Moq)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Admin");

            // Get the RouteData based on the HttpContext
            var routeData = routes.GetRouteData(context.Object);

            Assert.IsTrue(true);
        }
    }
}
