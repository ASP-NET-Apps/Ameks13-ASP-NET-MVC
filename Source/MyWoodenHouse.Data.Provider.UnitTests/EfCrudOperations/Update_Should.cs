using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.Data.Provider.UnitTest.EfCrudOperationsTests
{
    [TestClass]
    public class Update_Should
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
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            string errorMessage = nameof(nullableCategory);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.Update(nullableCategory), errorMessage);
        }

        [TestMethod]
        public void UpdateTheItemSpecifiedInTheInputParameter_WhenCalledWithValidCategoryObject()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(c => c.GetEntityState(It.IsAny<Category>()))
                .Returns(() => EntityState.Detached);

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var categoryToUpdate = actualService.SelectById(1);
            categoryToUpdate.Name = "This Name is changed";

            var id = actualService.Update(categoryToUpdate);
            var actualUpdatedCategory = actualService.SelectById(id);

            // Assert
            Assert.AreEqual(categoryToUpdate.Name, actualUpdatedCategory.Name);
        }

        [TestMethod]
        public void VerifyThatDbContextGetEntityStateMethodIsCalledOnce_WhenCalledWithValidCategoryObject()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(c => c.GetEntityState(It.IsAny<Category>()))
                .Returns(() => EntityState.Detached);

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var categoryToUpdate = actualService.SelectById(1);
            categoryToUpdate.Name = "This Name is changed";

            var id = actualService.Update(categoryToUpdate);

            // Assert
            mockedMyWoodenHouseDbContext.Verify(c => c.GetEntityState(It.IsAny<Category>()), Times.Once);
        }

        [TestMethod]
        public void VerifyThatDbContextSetEntityStateMethodIsCalledOnce_WhenCalledWithValidCategoryObject()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(c => c.GetEntityState(It.IsAny<Category>()))
                .Returns(() => EntityState.Detached);

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var categoryToUpdate = actualService.SelectById(1);
            categoryToUpdate.Name = "This Name is changed";

            var id = actualService.Update(categoryToUpdate);

            // Assert
            mockedMyWoodenHouseDbContext.Verify(c => c.SetEntityState(It.IsAny<Category>(), EntityState.Modified), Times.Once);
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
