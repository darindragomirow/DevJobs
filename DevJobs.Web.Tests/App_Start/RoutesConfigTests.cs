using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace DevJobs.Web.Tests.App_Start
{
    [TestFixture]
    public class RouteConfigTests
    {
        [Test]
        public void RegisterRoutes_ShouldEnforceLowerCaseRoutes()
        {
            // Arrange
            var routes = new RouteCollection();

            // Act
            RouteConfig.RegisterRoutes(routes);

            // Assert
            Assert.IsTrue(routes.LowercaseUrls);
        }
    }
}
