﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Extensions;
using System.Data.Entity;

namespace MyWoodenHouse.UnitTest.CategoryServiceCrudOperatonsTests
{
    [TestClass]
    public class Properties_Should
    {
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        [TestInitialize]
        public void TestInit()
        {
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();
        }

        [TestMethod]
        public void ExistContextProperty()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("Context"));
        }

        [TestMethod]
        public void ExistCategoryDbSetProperty()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("CategoryDbSet"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
        }
    }
}
