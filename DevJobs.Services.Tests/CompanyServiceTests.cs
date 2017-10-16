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
    public class CompanyServiceTests
    {
        public void GetAll_ShouldCallQueryAll()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Company>>();
            var saveContextMock = new Mock<ISaveContext>();

            var companyService = new CompanyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = companyService.GetAll();

            // Assert
            repositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldCallQueryAllAndDeleted()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Company>>();
            var saveContextMock = new Mock<ISaveContext>();

            var companyService = new CompanyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            var result = companyService.GetAllAndDeleted();

            // Assert
            repositoryMock.Verify(x => x.AllAndDeleted, Times.Once);
        }


        [Test]
        public void Add_ShouldCallRepoAdd()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Company>>();
            var saveContextMock = new Mock<ISaveContext>();
            Company company = new Company()
            {
                Name = "test",
                Description = "test"
            };

            var companyService = new CompanyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            companyService.Add(company);

            // Assert
            repositoryMock.Verify(x => x.Add(It.IsAny<Company>()), Times.Once);
        }

        [Test]
        public void Add_ShouldCallRepoAdd_AndCreateAddWithCorrectParameters()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Company>>();
            var saveContextMock = new Mock<ISaveContext>();
            Company company = new Company()
            {
                Name = "test",
                Description = "test"
            };

            var companyService = new CompanyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            companyService.Add(company);

            // Assert
            repositoryMock.Verify(x => x.Add(It.Is<Company>(a =>
                a.Name == "test" &&
                a.Description == "test")), Times.Once);
        }

        [Test]
        public void Update_ShouldCallRepoUpdate()
        {
            // Arrange
            var repositoryMock = new Mock<IEfRepository<Company>>();
            var saveContextMock = new Mock<ISaveContext>();
            Company company = new Company()
            {
                Name = "test",
                Description = "test"
            };

            var companyService = new CompanyService(repositoryMock.Object, saveContextMock.Object);

            // Act
            companyService.Update(company);

            // Assert
            repositoryMock.Verify(x => x.Update(It.IsAny<Company>()), Times.Once);
        }

    }
}
