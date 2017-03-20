using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.UnitTest.CategoryServiceCrudOperatonsTests
{
    [TestClass]
    public class Insert_Should
    {
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;
        private static IList<Category> fakeData;

        [TestInitialize]
        public void TestInitialize()
        {
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();

            fakeData = new List<Category> {
                new Category { Id = 1, Name = "House" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 3, Name = "Cabin" },
                new Category { Id = 4, Name = "Bungalow" }
            };

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.AsQueryable().Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.AsQueryable().Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.AsQueryable().ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.AsQueryable().GetEnumerator());

            mockedDbSet.Setup(m => m.Add(It.IsAny<Category>()))
                .Callback<Category>(c => fakeData.Add(c));
            mockedDbSet.Setup(m => m.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => fakeData.FirstOrDefault(d => d.Id == (int)ids[0]));
            
            mockedMyWoodenHouseDbContext.Setup(c => c.Set<Category>()).Returns(mockedDbSet.Object);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCalledNullableCategoryParameter()
        {
            // Arrange
            Category nullableCategory = null;

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            string errorMessage = nameof(nullableCategory);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.Insert(nullableCategory), errorMessage);
        }

        [TestMethod]
        public void AddOneItemToCategoriesCollection_WhenCalledWithValidCategoryObject()
        {
            // Arrange
            var categoryToAdd = new Category { Name = "The Fifth Category" };
            mockedMyWoodenHouseDbContext.Setup(c => c.GetEntityState(It.IsAny<Category>()))
                .Returns(() => EntityState.Detached);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var id = actualService.Insert(categoryToAdd);

            // Assert
            Assert.AreEqual(5, fakeData.Count());
        }

        [TestMethod]
        public void AddTheItemSpecifiedInTheInputParameter_WhenCalledWithValidCategoryObject()
        {
            // Arrange
            var categoryToAdd = new Category { Name = "The Fifth Category" };
            mockedMyWoodenHouseDbContext.Setup(c => c.GetEntityState(It.IsAny<Category>()))
                .Returns(() => EntityState.Detached);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var id = actualService.Insert(categoryToAdd);
            var actualCategory = actualService.SelectById(id);

            // Assert
            Assert.AreEqual(categoryToAdd.Name, actualCategory.Name);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
            fakeData = null;
        }
    }
}
