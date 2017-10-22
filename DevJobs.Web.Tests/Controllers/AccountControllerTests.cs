using DevJobs.Models;
using DevJobs.Web.Contracts;
using DevJobs.Web.Contracts.Identity;
using DevJobs.Web.Controllers;
using DevJobs.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevJobs.Web.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        [Test]
        public void LoginGet_ShouldReturnView()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var userManagerMock = new Mock<IApplicationUserManager>();
            var authManager = new Mock<IAuthenticationManager>();

            var controller = new AccountController(
                userManagerMock.Object,
                signInManagerMock.Object,
                authManager.Object);

            // Act
            var result = controller.Login(string.Empty);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void LoginPost_ShouldReDisplayFormIfThereAreModelErrors()
        {
            // Arrange
            var userManagerMock = new Mock<IApplicationUserManager>();
            var authManager = new Mock<IAuthenticationManager>();
            var signInManagerMock = new Mock<IApplicationSignInManager>();

            var controller = new AccountController(
                userManagerMock.Object,
                signInManagerMock.Object,
                authManager.Object)
            {
                Url = new Mock<UrlHelper>().Object
            };
            controller.ModelState.AddModelError("", "");

            var model = new LoginViewModel();

            // Act
            var result = controller.Login(model, "").Result;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void LoginPost_ShouldReDisplayFormIfThereIsASignInError()
        {
            // Arrange
            var userManagerMock = new Mock<IApplicationUserManager>();
            var authManager = new Mock<IAuthenticationManager>();

            var signInManagerMock = new Mock<IApplicationSignInManager>();
            signInManagerMock
                .Setup(x => x.PasswordSignInAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>()))
                .ReturnsAsync(SignInStatus.Failure);

            var controller = new AccountController(
                userManagerMock.Object,
                signInManagerMock.Object,
                authManager.Object)
            {
                Url = new Mock<UrlHelper>().Object
            };

            var model = new LoginViewModel();

            // Act
            var result = controller.Login(model, "").Result;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void RegisterGet_ShouldReturnView()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var userManagerMock = new Mock<IApplicationUserManager>();
            var authManager = new Mock<IAuthenticationManager>();

            var controller = new AccountController(
                userManagerMock.Object,
                signInManagerMock.Object,
                authManager.Object);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void RegisterPost_ShouldCallCreateAsyncWithCorectArgs()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var authManager = new Mock<IAuthenticationManager>();

            var userManagerMock = new Mock<IApplicationUserManager>();
            userManagerMock
                .Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            var controller = new AccountController(
                userManagerMock.Object,
                signInManagerMock.Object,
                authManager.Object)
            {
                Url = new Mock<UrlHelper>().Object
            };

            var model = new RegisterViewModel
            {
                Email = "username",
                Password = "passowrd",
                ConfirmPassword = "password",
            };

            // Act
            var result = controller.Register(model).Result;

            // Assert
            userManagerMock.Verify(x => x.CreateAsync(
                It.IsAny<User>(),
                It.Is<string>(y => y == model.Password)));
        }

        [Test]
        public void RegisterPost_ShouldAddErrorsWhenNeeded()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var authManager = new Mock<IAuthenticationManager>();

            var userManagerMock = new Mock<IApplicationUserManager>();
            userManagerMock
                .Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed("error"));

            var controller = new AccountController(
                userManagerMock.Object,
                signInManagerMock.Object,
                authManager.Object)
            {
                Url = new Mock<UrlHelper>().Object
            };

            var model = new RegisterViewModel();

            // Act
            var result = controller.Register(model).Result;

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
        }



        [Test]
        public void LogOff_ShouldCallCreateSignOutAndRedirect()
        {
            // Arrange
            var signInManagerMock = new Mock<IApplicationSignInManager>();
            var authManagerMock = new Mock<IAuthenticationManager>();
            var userManagerMock = new Mock<IApplicationUserManager>();

            var controller = new AccountController(
                userManagerMock.Object,
                signInManagerMock.Object,
                authManagerMock.Object);

            // Act
            var result = controller.LogOff();

            // Assert
            authManagerMock.Verify(x => x.SignOut(It.IsAny<string>()), Times.Once);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
    }
}
