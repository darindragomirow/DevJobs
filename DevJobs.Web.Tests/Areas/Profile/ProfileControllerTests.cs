using AutoMapper;
using DevJobs.Services.Contracts;
using DevJobs.Web.Areas.Profile.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevJobs.Web.Tests.Areas.Profile
{
    [TestFixture]
    public class ProfileControllerTests
    {

        [Test]
        public void Index_ShouldReturnViewResult()
        {
            //Arrange
            var adServiceMock = new Mock<IAdService>();
            var mapper = new Mock<IMapper>();

            var controller = new ProfileController
                (
                    adServiceMock.Object,
                    mapper.Object
                );

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
