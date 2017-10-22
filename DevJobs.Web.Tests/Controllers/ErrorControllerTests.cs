using DevJobs.Web.Controllers;
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
    public class ErrorControllerTests
    {
        [Test]
        public void Index_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ErrorController();

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void NotFound_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ErrorController();

            //Act
            var result = controller.NotFound() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
