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
    public class AccountControllerTests
    {
        [Test]
        public void Login_ShouldReturnViewResult()
        {
            //Arrange
            string url = "www.test.com";

            var controller = new AccountController();

            //Act
            var result = controller.Login(url) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Register_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new AccountController();

            //Act
            var result = controller.Register() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ForgotPassword_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new AccountController();

            //Act
            var result = controller.ForgotPassword() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ResetPassword_ShouldReturnViewResult()
        {
            //Arrange
            string code = "newpass";
            var controller = new AccountController();

            //Act
            var result = controller.ResetPassword(code) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ResetPasswordConfirmation_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new AccountController();

            //Act
            var result = controller.ResetPasswordConfirmation() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }


    }
}
