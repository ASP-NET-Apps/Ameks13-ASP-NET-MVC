using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Ef.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.UnitTest.CategoryServiceCrudOperatonsTests
{
    [TestClass]
    public class SelectFiltered_Should
    {
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        [TestInitialize]
        public void TestInitialize()
        {
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();
        }

        [TestMethod]
        public void ReturnOneFilteredCategory_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Arrange
            var fakeData = new List<Category> {
                new Category { Name = "House" },
                new Category { Name = "Garage" },
                new Category { Name = "Cabin" },
                new Category { Name = "Bungalow" }
            }.AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.Select(c => c.Name == "House");

            // Assert
            Assert.AreEqual(1, actualFilteredCategories.Count());
        }

        [TestMethod]
        public void ReturnOneCategoriesWithTheFilteredName_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Arrange
            var fakeData = new List<Category> {
                new Category { Name = "House" },
                new Category { Name = "Garage" },
                new Category { Name = "Cabin" },
                new Category { Name = "Bungalow" }
            }.AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.Select(c => c.Name == "House");

            // Assert
            Assert.AreEqual(fakeData.ToList()[0].Name, actualFilteredCategories.ToList()[0].Name);
        }

        [TestMethod]
        public void ReturnTwoFilteredCategories_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Arrange
            var fakeData = new List<Category> {
                new Category { Name = "House" },
                new Category { Name = "Garage" },
                new Category { Name = "Cabin" },
                new Category { Name = "Bungalow" }
            }.AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.Select(c => (c.Name == "House" || c.Name == "Garage"));

            // Assert
            Assert.AreEqual(2, actualFilteredCategories.Count());
        }

        [TestMethod]
        public void ReturnTwoCategoriesWithTheFilteredNames_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Arrange
            var fakeData = new List<Category> {
                new Category { Name = "House" },
                new Category { Name = "Garage" },
                new Category { Name = "Cabin" },
                new Category { Name = "Bungalow" }
            }.AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.Select(c => (c.Name == "House" || c.Name == "Garage"));

            // Assert
            Assert.AreEqual(fakeData.ToList()[0].Name, actualFilteredCategories.ToList()[0].Name);
            Assert.AreEqual(fakeData.ToList()[1].Name, actualFilteredCategories.ToList()[1].Name);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
        }
    }
}
