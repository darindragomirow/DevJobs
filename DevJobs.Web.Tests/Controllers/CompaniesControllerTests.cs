﻿using AutoMapper;
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
    public class CompaniesControllerTests
    {
        [Test]
        public void GetAll_ShouldReturnResultView()
        {
            //Arrange
            var companyServiceMock = new Mock<ICompanyService>();
            var adServiceMock = new Mock<IAdService>();
            var mapper = new Mock<IMapper>();
            int page = 3;

            var controller = new CompaniesController
                (
                companyServiceMock.Object,
                adServiceMock.Object,
                mapper.Object
                );

            //Act
            var result = controller.GetAll(page) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetDetails_ShouldReturnResultView()
        {
            //Arrange
            var companyServiceMock = new Mock<ICompanyService>();
            var mapper = new Mock<IMapper>();
            var adServiceMock = new Mock<IAdService>();
            Guid id = Guid.NewGuid();

            var controller = new CompaniesController
                (
                companyServiceMock.Object,
                adServiceMock.Object,
                mapper.Object
                );

            //Act
            var result = controller.GetDetails(id) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
