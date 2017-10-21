using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;
using DevJobs.Services.Tests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevJobs.Services.Contracts;
using DevJobs.Models;

namespace DevJobs.Services.Tests
{
    [TestFixture]
    public class AdServiceTests
    {
        [Test]
        public void GetAll_ShouldCallQueryAll()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = adService.GetAll();

            // Assert
            repositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldCallQueryAllAndDeleted()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = adService.GetAllAndDeleted();

            // Assert
            repositoryMock.Verify(x => x.AllAndDeleted, Times.Once);
        }

        [Test]
        public void GetFiltered_ShouldCallQueryAll()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();
            string searchTerm = "";
            string location = "Sofiq";
            string technology = "ASP.NET";

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = adService.GetFiltered(searchTerm, location, technology);

            // Assert
            repositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetFiltered_ShouldCallQueryAllIfThereIsSearchTerm()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();
            string searchTerm = "test";
            string location = "Sofiq";
            string technology = "ASP.NET";

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = adService.GetFiltered(searchTerm, location, technology);

            // Assert
            repositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void Add_ShouldCallRepoAdd()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();
            Advert advert = new Advert()
            {
                Title = "test",
                Description = "test"
            };

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            adService.Add(advert);

            // Assert
            repositoryMock.Verify(x => x.Add(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void Add_ShouldCallRepoAdd_AndCreateAddWithCorrectParameters()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();
            Advert advert = new Advert()
            {
                Title = "test",
                Description = "test"
            };

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            adService.Add(advert);

            // Assert
            repositoryMock.Verify(x => x.Add(It.Is<Advert>(a =>
                a.Title == "test" &&
                a.Description == "test")), Times.Once);
        }

        [Test]
        public void Update_ShouldCallRepoUpdate()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();
            Advert advert = new Advert()
            {
                Title = "test",
                Description = "test"
            };

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            adService.Update(advert);

            // Assert
            repositoryMock.Verify(x => x.Update(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void AddPreview_ShouldIncrementGivenAdPreviews()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Advert>>();
            var saveContextMock = new Mock<ISaveContext>();
            var ad = new Advert()
            {
                Title = "test",
                Description = "test",
                PreViews = 5,
                Salary = 500,
                City = new City(),
                CityId = Guid.NewGuid(),
                CountryId = Guid.NewGuid(),
                Country = new Country() { Name = "Bulgaria", Adverts = new List<Advert>() },
                Company = new Company(),
                CompanyId = Guid.NewGuid(),
                Technology = new Models.Models.Technology(),
                TechnologyId = Guid.NewGuid(),
                Level = new Models.Models.Level(),
                LevelId = Guid.NewGuid(),
                IsDeleted = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                DeletedOn = DateTime.Now,
            };

            var adService = new AdService(repositoryMock.Object, saveContextMock.Object);

            // Act
            adService.AddPreview(ad);

            // Assert
            Assert.AreEqual(ad.PreViews, 6);
        }
    }
}
