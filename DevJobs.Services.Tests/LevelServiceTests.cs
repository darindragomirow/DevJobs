using DevJobs.Data.Repositories;
using DevJobs.Data.SaveContext;
using DevJobs.Models;
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
    public class LevelServiceTests
    {
        [Test]
        public void GetAll_ShouldCallQueryAll()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Level>>();
            var saveContextMock = new Mock<ISaveContext>();

            var levelService = new LevelService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = levelService.GetAll();

            // Assert
            repositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldCallQueryAllAndDeleted()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Level>>();
            var saveContextMock = new Mock<ISaveContext>();

            var levelService = new LevelService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = levelService.GetAllAndDeleted();

            // Assert
            repositoryMock.Verify(x => x.AllAndDeleted, Times.Once);
        }


        [Test]
        public void Add_ShouldCallRepoAdd()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Level>>();
            var saveContextMock = new Mock<ISaveContext>();
            Level level = new Level()
            {
                Type = "test",
            };

            var levelService = new LevelService(repositoryMock.Object, saveContextMock.Object);

            // Act
            levelService.Add(level);

            // Assert
            repositoryMock.Verify(x => x.Add(It.IsAny<Level>()), Times.Once);
        }

        [Test]
        public void Add_ShouldCallRepoAdd_AndCreateAddWithCorrectParameters()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Level>>();
            var saveContextMock = new Mock<ISaveContext>();
            Level level = new Level()
            {
                Type = "test",
            };

            var levelService = new LevelService(repositoryMock.Object, saveContextMock.Object);

            // Act
            levelService.Add(level);

            // Assert
            repositoryMock.Verify(x => x.Add(It.Is<Level>
                (a => a.Type == "test")), Times.Once);
        }

        [Test]
        public void Update_ShouldCallRepoUpdate()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Level>>();
            var saveContextMock = new Mock<ISaveContext>();
            Level level = new Level()
            {
                Type = "test",
            };

            var levelService = new LevelService(repositoryMock.Object, saveContextMock.Object);

            // Act
            levelService.Update(level);

            // Assert
            repositoryMock.Verify(x => x.Update(It.IsAny<Level>()), Times.Once);
        }
    }
}
