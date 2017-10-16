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
using NUnit.Framework;

namespace DevJobs.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_ShouldReturnViewResult()
        {
            // Arrange
            var adServiceMock = new Mock<IAdService>();
            var companyServiceMock = new Mock<ICompanyService>();
            var mapper = new Mock<IMapper>();

            var controller = new HomeController
                (
                    adServiceMock.Object,
                    companyServiceMock.Object,
                    mapper.Object
                );

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            NUnit.Framework.Assert.IsNotNull(result);
        }

        [Test]
        public void About_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            NUnit.Framework.Assert.IsNotNull(result);
        }

        [Test]
        public void Contact_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Contact() as ViewResult;

            //Assert
            NUnit.Framework.Assert.IsNotNull(result);
        }
    }


}
