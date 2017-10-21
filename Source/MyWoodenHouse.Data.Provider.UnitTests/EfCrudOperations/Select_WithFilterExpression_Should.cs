using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.Data.Provider.UnitTest.EfCrudOperationsTests
{
    [TestClass]
    public class Select_WithFilterExpression_Should
    {
        private static Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;
        private static IQueryable<Category> fakeData;


        [TestInitialize]
        public void TestInitialize()
        {
            mockedMyWoodenHouseDbContext = new Mock<MyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();

            fakeData = new List<Category> {
                new Category { Id = 1, Name = "House" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 3, Name = "Cabin" },
                new Category { Id = 4, Name = "Bungalow" }
            }.AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);
        }

        [TestMethod]
        public void ReturnOneFilteredCategory_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Done in the TestInitialize method
            
            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.SelectAll(c => c.Name == "House");

            // Assert
            Assert.AreEqual(1, actualFilteredCategories.Count());
        }

        [TestMethod]
        public void ReturnOneCategoriesWithTheFilteredName_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Done in the TestInitialize method
            
            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.SelectAll(c => c.Name == "House");

            // Assert
            Assert.AreEqual(fakeData.ToList()[0].Name, actualFilteredCategories.ToList()[0].Name);
        }

        [TestMethod]
        public void ReturnTwoFilteredCategories_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Done in the TestInitialize method
            
            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.SelectAll(c => (c.Name == "House" || c.Name == "Garage"));

            // Assert
            Assert.AreEqual(2, actualFilteredCategories.Count());
        }

        [TestMethod]
        public void ReturnTwoCategoriesWithTheFilteredNames_WhenColledWithAPropreFilterExpression()
        {
            // Arrange
            // Done in the TestInitialize method
            
            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualFilteredCategories = actualService.SelectAll(c => (c.Name == "House" || c.Name == "Garage"));

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
