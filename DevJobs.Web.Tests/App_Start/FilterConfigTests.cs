using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevJobs.Web.Tests.App_Start
{
    [TestFixture]
    public class FilterConfigTests
    {
        [Test]
        public void RegisterFilters_ShouldRegisterRequiredFilters()
        {
            //Arrange
            var filters = new GlobalFilterCollection();

            //Act
            FilterConfig.RegisterGlobalFilters(filters);

            //Assert
            Assert.IsNotNull(filters);
        }
    }
}
