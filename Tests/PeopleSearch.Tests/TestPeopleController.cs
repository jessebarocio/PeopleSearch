using Moq;
using NUnit.Framework;
using PeopleSearch.Controllers;
using PeopleSearch.Data;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace PeopleSearch.Tests
{
    [TestFixture]
    class TestPeopleController
    {
        Mock<IPeopleRepository> _peopleRepoMock;
        Mock<IPhotoRepository> _photoRepoMock;
        PeopleController _controller;

        [SetUp]
        public void SetUp()
        {
            _peopleRepoMock = new Mock<IPeopleRepository>();
            _photoRepoMock = new Mock<IPhotoRepository>();
            _controller = new PeopleController(_peopleRepoMock.Object, _photoRepoMock.Object);
        }

        [Test]
        public async Task SearchByNameAsync_PassesSearchParameterToRepository()
        {
            // Arrange
            string searchString = "this is my search string";
            _peopleRepoMock.Setup(p => p.SearchByNameAsync(searchString))
                .ReturnsAsync(new List<Person>())
                .Verifiable();
            // Act
            var result = await _controller.SearchByNameAsync(searchString);
            // Assert
            Mock.Verify(_peopleRepoMock);
        }

        [Test]
        public async Task PostPersonAsync_PassesPersonToRepository()
        {
            // Arrange
            var person = new PersonDTO();
            _peopleRepoMock.Setup(p => p.InsertPersonAsync(It.IsAny<Person>()))
                .ReturnsAsync(new Person() { PersonId = 5 })
                .Verifiable();
            // Act
            var result = await _controller.PostPersonAsync(person);
            // Assert
            Mock.Verify(_peopleRepoMock);
            Assert.AreEqual(5, person.PersonId);
        }

        [Test]
        public async Task GetPhotoAsync_RetrievesPhotoFromRepository()
        {
            // Arrange
            int personId = 5;
            Person personEntity = new Person() { PhotoId = 500 };
            Photo photoEntity = new Photo() { Data = new byte[] { }, ContentType = "testContentType" };
            _peopleRepoMock.Setup(s => s.GetPersonAsync(personId))
                .ReturnsAsync(personEntity)
                .Verifiable();
            _photoRepoMock.Setup(s => s.GetPhotoAsync(personEntity.PhotoId.Value))
                .ReturnsAsync(photoEntity)
                .Verifiable();
            // Act
            var result = await _controller.GetPhotoAsync(personId);
            // Assert
            Mock.Verify(_peopleRepoMock);
            Mock.Verify(_photoRepoMock);
            Assert.AreSame(photoEntity.ContentType, result.ContentType);
        }
    }
}
