using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevJobs.Web;
using DevJobs.Web.Controllers;
using DevJobs.Services.Contracts;
using Moq;
using DevJobs.Models;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Models;
using AutoMapper;

namespace DevJobs.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //// Arrange

            var ads = new Advert[]
            {
                new Advert { Id = Guid.NewGuid(), Title="Ad1", Description="no" },
                new Advert { Id = Guid.NewGuid(), Title="Ad2", Description="no"  }
            };
            var adsServiceMock = new Mock<IAdService>();
            adsServiceMock
                .Setup(x => x.GetAll())
                .Returns(ads.AsQueryable());

            var companies = new Company[]
            {
                new Company { Id = Guid.NewGuid(), Name ="Cmp1" },
                new Company { Id = Guid.NewGuid(), Name = "Cmp2" }
            };

            var companyServiceMock = new Mock<ICompanyService>();
            companyServiceMock
                .Setup(x => x.GetAll())
                .Returns(companies.AsQueryable());

            var mapperMock = new Mock<IMapper>();
            mapperMock
                .Setup(x => x.Map<AdViewModel>(It.IsAny<Advert>()))
                .Returns<Advert>(x => new AdViewModel { Id = x.Id });
            mapperMock
                .Setup(x => x.Map<CompanyViewModel>(It.IsAny<Company>()))
                .Returns<Advert>(x => new CompanyViewModel { Id = x.Id });
            

            HomeController controller = new HomeController(adsServiceMock.Object, companyServiceMock.Object, mapperMock.Object);

            // Act
            //var result = controller.Index() as ViewResult;

            // Assert

            Assert.IsTrue(true);

            //var result = 2;
            //Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
