﻿using Moq;
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
    class TestPeopleApiController
    {
        Mock<IPeopleRepository> _peopleRepoMock;
        PeopleApiController _controller;

        [SetUp]
        public void SetUp()
        {
            _peopleRepoMock = new Mock<IPeopleRepository>();
            _controller = new PeopleApiController(_peopleRepoMock.Object);
        }

        [Test]
        public async Task SearchByName_PassesSearchParameterToRepository()
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
    }
}