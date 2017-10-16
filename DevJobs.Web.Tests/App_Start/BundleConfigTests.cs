using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace DevJobs.Web.Tests.App_Start
{
    [TestFixture]
    public class BundleConfigTests
    {
        [Test]
        public void RegisterBundles_ShouldRegisterRequiredBundles()
        {
            // Arrange
            var bundles = new BundleCollection();

            // Act
            BundleConfig.RegisterBundles(bundles);

            // Assert
            Assert.IsNotNull(bundles);
            Assert.IsTrue(bundles.Any(x => x.Path == "~/bundles/jquery"));
            Assert.IsTrue(bundles.Any(x => x.Path == "~/bundles/jqueryval"));
            Assert.IsTrue(bundles.Any(x => x.Path == "~/bundles/modernizr"));
            Assert.IsTrue(bundles.Any(x => x.Path == "~/bundles/bootstrap"));
            Assert.IsTrue(bundles.Any(x => x.Path == "~/Content/css"));
        }
    }
}

