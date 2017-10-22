using DevJobs.Web.Contracts;
using DevJobs.Web.Contracts.Identity;
using DevJobs.Web.Controllers;
using DevJobs.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static DevJobs.Web.Controllers.ManageController;

namespace DevJobs.Web.Tests.Controllers
{
    [TestFixture]
    public class ManageControllerTests
    {
        [Test]
        public void Index_ShouldReturnViewResult()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var userManagerMock = new Mock<IApplicationUserManager>();

            var controller = new ManageController(userManagerMock.Object, signInManagerMock.Object);

            // Act
            var result = controller.Index(null);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        [TestCase(ManageMessageId.Error, "error")]
        [TestCase(ManageMessageId.ChnageEmailSuccess, "email")]
        [TestCase(ManageMessageId.ChangePasswordSuccess, "password")]
        [TestCase(null, "")]
        public void Index_ShouldDisplayMessage(ManageMessageId messageId, string expected)
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var userManagerMock = new Mock<IApplicationUserManager>();

            var controller = new ManageController(userManagerMock.Object, signInManagerMock.Object);

            // Act
            var result = controller.Index(messageId);

            // Assert
            StringAssert.Contains(expected, controller.ViewBag.StatusMessage);
        }

        [Test]
        public void ChangePassword_ShouldReturnViewResult()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var userManagerMock = new Mock<IApplicationUserManager>();

            var controller = new ManageController(userManagerMock.Object, signInManagerMock.Object);

            // Act
            var result = controller.ChangePassword();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void ChangePasswordPost_ShouldCallChangePasswordAsync()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var userManagerMock = new Mock<IApplicationUserManager>();

            var model = new ChangePasswordViewModel
            {
                OldPassword = "oldpass",
                NewPassword = "pass",
                ConfirmPassword = "pass",
            };

            var controllerContextMock = new Mock<ControllerContext>();
            var identityMock = new Mock<IIdentity>();
            var principalMock = new Mock<IPrincipal>();
            principalMock.Setup(x => x.Identity).Returns(identityMock.Object);
            controllerContextMock.Setup(x => x.HttpContext.User).Returns(principalMock.Object);

            var controller = new ManageController(userManagerMock.Object, signInManagerMock.Object)
            {
                ControllerContext = controllerContextMock.Object
            };

            // Act
            var result = controller.ChangePassword(model);

            // Assert
            userManagerMock.Verify(x => x.ChangePasswordAsync(
                It.IsAny<string>(),
                It.Is<string>(y => y == model.OldPassword),
                It.Is<string>(y => y == model.NewPassword)), Times.Once);
        }
    }
}
