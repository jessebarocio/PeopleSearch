using Moq;
using NUnit.Framework;
using PeopleSearch.Controllers;
using PeopleSearch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Tests
{
    [TestFixture]
    class TestPersonApiController
    {
        Mock<IPersonRepository> _personRepoMock;
        PersonApiController _controller;

        [SetUp]
        public void SetUp()
        {
            _personRepoMock = new Mock<IPersonRepository>();
            _controller = new PersonApiController(_personRepoMock.Object);
        }

        [Test]
        public async Task SearchByName_PassesSearchParameterToRepository()
        {
            // Arrange
            string searchString = "this is my search string";
            _personRepoMock.Setup(p => p.SearchByNameAsync(searchString))
                .ReturnsAsync(new List<Person>())
                .Verifiable();
            // Act
            var result = await _controller.SearchByNameAsync(searchString);
            // Assert
            Mock.Verify(_personRepoMock);
        }
    }
}
