using DevJobs.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Web.Tests.Models
{
    [TestFixture]
    public class MainViewModelTests
    {

        [Test]
        public void MainViewModel_ShouldSetCorrectPropertiesWhenCreated()
        {
            //Arrange
            ICollection<AdViewModel> ads = new List<AdViewModel>();
            ICollection<CompanyViewModel> companies = new List<CompanyViewModel>();

            var model = new MainViewModel()
            {
                Companies = companies,
                Ads = ads,
            };

            //Act & Assert
            Assert.AreEqual(model.Ads, ads);
            Assert.AreEqual(model.Companies, companies);
        }
    }
}
