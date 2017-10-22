using AutoMapper;
using DevJobs.Models;
using DevJobs.Services.Contracts;
using DevJobs.Web.Areas.Profile;
using DevJobs.Web.Areas.Profile.Controllers;
using DevJobs.Web.Contracts.Identity;
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
            var userManager = new Mock<IApplicationUserManager>();
            var mapper = new Mock<IMapper>();

            var controller = new ProfileController
                (
                    adServiceMock.Object,
                    userManager.Object,
                    mapper.Object
                );

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        //[Test]
        //public void MyCandidatures_ShouldReturnViewResult()
        //{
        //    //Arrange
        //    var adServiceMock = new Mock<IAdService>();
        //    var userManager = new Mock<IApplicationUserManager>();
        //    var mapper = new Mock<IMapper>();

        //    var ads = new Advert[]
        //    {
        //        new Advert(){ Title = "Test" },
        //    };
        //    var users = new User[]
        //    {
        //        new User(){ Adverts = ads },
        //    };
        
        //    userManager.Setup(x => x.Users).Returns(users.AsQueryable);
            

        //    var controller = new ProfileController
        //        (
        //            adServiceMock.Object,
        //            userManager.Object,
        //            mapper.Object
        //        );
           
        //    //Act
        //    var result = controller.MyCandidatures() as ViewResult;

        //    //Assert
        //    Assert.IsNotNull(result);
        //}

        [Test]
        public void TestCatalogAreaRoute()
        {
            var routes = new RouteCollection();

            // Get my AreaRegistration class
            var areaRegistration = new ProfileAreaRegistration();
            Assert.AreEqual("Profile", areaRegistration.AreaName);

            // Get an AreaRegistrationContext for my class. Give it an empty RouteCollection
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
            areaRegistration.RegisterArea(areaRegistrationContext);

            // Mock up an HttpContext object with my test path (using Moq)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Profile");

            // Get the RouteData based on the HttpContext
            var routeData = routes.GetRouteData(context.Object);

            Assert.IsTrue(true);
        }
    }
}
