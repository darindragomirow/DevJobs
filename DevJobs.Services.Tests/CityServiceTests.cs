using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;
using DevJobs.Models;
using DevJobs.Servicess;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Services.Tests
{
    [TestFixture]
    public class CityServiceTests
    {
        [Test]
        public void GetAll_ShouldCallQueryAll()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<City>>();
            var saveContextMock = new Mock<ISaveContext>();

            var cityService = new CityService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = cityService.GetAll();

            // Assert
            repositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldCallQueryAllAndDeleted()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<City>>();
            var saveContextMock = new Mock<ISaveContext>();

            var cityService = new CityService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = cityService.GetAllAndDeleted();

            // Assert
            repositoryMock.Verify(x => x.AllAndDeleted, Times.Once);
        }


        [Test]
        public void Add_ShouldCallRepoAdd()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<City>>();
            var saveContextMock = new Mock<ISaveContext>();
            City city = new City()
            {
                Name = "test",
            };

            var cityService = new CityService(repositoryMock.Object, saveContextMock.Object);

            // Act
            cityService.Add(city);

            // Assert
            repositoryMock.Verify(x => x.Add(It.IsAny<City>()), Times.Once);
        }

        [Test]
        public void Add_ShouldCallRepoAdd_AndCreateAddWithCorrectParameters()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<City>>();
            var saveContextMock = new Mock<ISaveContext>();
            City city = new City()
            {
                Name = "test",
            };

            var cityService = new CityService(repositoryMock.Object, saveContextMock.Object);

            // Act
            cityService.Add(city);

            // Assert
            repositoryMock.Verify(x => x.Add(It.Is<City>
                (a => a.Name == "test" )), Times.Once);
        }

        [Test]
        public void Update_ShouldCallRepoUpdate()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<City>>();
            var saveContextMock = new Mock<ISaveContext>();
            City city = new City()
            {
                Name = "test",
            };

            var cityService = new CityService(repositoryMock.Object, saveContextMock.Object);

            // Act
            cityService.Update(city);

            // Assert
            repositoryMock.Verify(x => x.Update(It.IsAny<City>()), Times.Once);
        }
    }
}
