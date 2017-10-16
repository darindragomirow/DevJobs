using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;
using DevJobs.Models.Models;
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
    public class TechnologyServiceTests
    {
        [Test]
        public void GetAll_ShouldCallQueryAll()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Technology>>();
            var saveContextMock = new Mock<ISaveContext>();

            var technologyService = new TechnologyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = technologyService.GetAll();

            // Assert
            repositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldCallQueryAllAndDeleted()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Technology>>();
            var saveContextMock = new Mock<ISaveContext>();

            var technologyService = new TechnologyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = technologyService.GetAllAndDeleted();

            // Assert
            repositoryMock.Verify(x => x.AllAndDeleted, Times.Once);
        }


        [Test]
        public void Add_ShouldCallRepoAdd()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Technology>>();
            var saveContextMock = new Mock<ISaveContext>();
            Technology technology = new Technology()
            {
                Type = "test",
            };

            var technologyService = new TechnologyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            technologyService.Add(technology);

            // Assert
            repositoryMock.Verify(x => x.Add(It.IsAny<Technology>()), Times.Once);
        }

        [Test]
        public void Add_ShouldCallRepoAdd_AndCreateAddWithCorrectParameters()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Technology>>();
            var saveContextMock = new Mock<ISaveContext>();
            Technology technology = new Technology()
            {
                Type = "test",
            };

            var technologyService = new TechnologyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            technologyService.Add(technology);

            // Assert
            repositoryMock.Verify(x => x.Add(It.Is<Technology>
                (a => a.Type == "test")), Times.Once);
        }

        [Test]
        public void Update_ShouldCallRepoUpdate()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Technology>>();
            var saveContextMock = new Mock<ISaveContext>();
            Technology technology = new Technology()
            {
                Type = "test",
            };

            var technologyService = new TechnologyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            technologyService.Update(technology);

            // Assert
            repositoryMock.Verify(x => x.Update(It.IsAny<Technology>()), Times.Once);
        }
    }
}

