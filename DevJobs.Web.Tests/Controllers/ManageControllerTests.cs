using DevJobs.Web.Controllers;
using DevJobs.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Web.Tests.Controllers
{
    [TestFixture]
    public class ManageControllerTests
    {
        [Test]
        public void Index_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();

            //Act
            var result = controller.Index(new ManageController.ManageMessageId());

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RemoveLogin_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();

            //Act
            var result = controller.RemoveLogin("test", "test");

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddPhoneNumber_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();

            //Act
            var result = controller.AddPhoneNumber();

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddPhoneNumberWithModel_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            var model = new AddPhoneNumberViewModel();
            //Act
            var result = controller.AddPhoneNumber(model);

            //Asssert
            Assert.IsNotNull(result);
        }
        
        [Test]
        public void EnableTwoFactorAuthentication_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.EnableTwoFactorAuthentication();

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DisableTwoFactorAuthentication_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.DisableTwoFactorAuthentication();

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void VerifyPhoneNumber_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.VerifyPhoneNumber("08888888888");

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void VerifyPhoneNumberWithModel_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.VerifyPhoneNumber(new VerifyPhoneNumberViewModel());

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RemovePhoneNumber_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.RemovePhoneNumber();

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ChangePassword_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.ChangePassword();

            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void SetPassword_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.SetPassword();
            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void SetPasswordWithModel_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.SetPassword(new SetPasswordViewModel());
            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ManageLogins_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.ManageLogins(new ManageController.ManageMessageId());
            //Asssert
            Assert.IsNotNull(result);
        }

        [Test]
        public void LinkLoginCallback_ShouldReturnViewResult()
        {
            //Arrange
            var controller = new ManageController();
            //Act
            var result = controller.LinkLoginCallback();
            //Asssert
            Assert.IsNotNull(result);
        }
    }
}
