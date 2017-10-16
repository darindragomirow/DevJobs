using AutoMapper;
using DevJobs.Services.Contracts;
using DevJobs.Servicess.Contracts;
using DevJobs.Web.Controllers;
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
            var cityServiceMock = new Mock<ICityService>();
            var mapper = new Mock<IMapper>();
            int page = 1;

            var controller = new AdsController
                (
                adServiceMock.Object,
                cityServiceMock.Object,
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
            var cityServiceMock = new Mock<ICityService>();
            var mapper = new Mock<IMapper>();
            Guid id = Guid.NewGuid();

            var controller = new AdsController
                (
                adServiceMock.Object,
                cityServiceMock.Object,
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
            var cityServiceMock = new Mock<ICityService>();
            var mapper = new Mock<IMapper>();
            Guid id = Guid.NewGuid();

            var controller = new AdsController
                (
                adServiceMock.Object,
                cityServiceMock.Object,
                mapper.Object
                );

            //Act
            var result = controller.GetFiltered() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
