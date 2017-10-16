using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Areas.Admin.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var controller = new AdminAdsController
                (
                    adServiceMock.Object,
                    cityServiceMock.Object,
                    companyServiceMock.Object,
                    technologyServiceMock.Object,
                    levelServiceMock.Object
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

            var controller = new AdminAdsController
                (
                    adServiceMock.Object,
                    cityServiceMock.Object,
                    companyServiceMock.Object,
                    technologyServiceMock.Object,
                    levelServiceMock.Object
                );

            //Act
            var result = controller.CreateAd() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
