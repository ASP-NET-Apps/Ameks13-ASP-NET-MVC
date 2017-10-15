using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services.UnitTest.CategoryServiceTests
{
    [TestClass]
    public class GetAllCategories_Should
    {
        private static Mock<IEfCrudOperatons<Category>> mockedCategoryBaseOperatonsProvider;
        private static Mock<IEfDbContextSaveChanges> mockedDbContextSaveChanges;

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedCategoryBaseOperatonsProvider = new Mock<IEfCrudOperatons<Category>>();
            mockedDbContextSaveChanges = new Mock<IEfDbContextSaveChanges>();
        }

        [TestMethod]
        public void ReturnFourCategories_WhenFourCategoriesInTheCollection()
        {
            // Arrange
            IQueryable<Category> fakeData = new List<Category> {
                new Category { Id = 1, Name = "House" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 3, Name = "Cabin" },
                new Category { Id = 4, Name = "Bungalow" }
            }.AsQueryable();

            mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);
            
            // Act
            CategoryService actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            IEnumerable<Category> actualCategories = actualInstance.GetAll();

            // Assert
            Assert.AreEqual(4, actualCategories.Count());
        }

        [TestMethod]
        public void ThrowArgumentNullException_ReturnedCategoriesObjectIsNull()
        {
            // Arrange
            IQueryable<Category> fakeData = null;
            mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);
            
            // Act
            CategoryService actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualInstance.GetAll());
        }

        [TestMethod]
        public void ReturnNull_WhenThereAreNocategoriesInTheCollection()
        {
            // Arrange
            IQueryable<Category> fakeData = new List<Category>().AsQueryable();
            mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);

            // Act
            CategoryService actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            IEnumerable<Category> actualCategories = actualInstance.GetAll();

            // Assert
            Assert.AreSame(null, actualCategories);
        }

        [TestMethod]
        public void ExecuteAllPropOnce_WhenCalled()
        {
            // Arrange
            IQueryable<Category> fakeData = new List<Category> {
                new Category { Id = 1, Name = "House" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 3, Name = "Cabin" },
                new Category { Id = 4, Name = "Bungalow" }
            }.AsQueryable();
            mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);

            // Act
            CategoryService actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            IEnumerable<Category> actualCategories = actualInstance.GetAll();

            // Assert
            mockedCategoryBaseOperatonsProvider.Verify(c => c.All, Times.Once);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedCategoryBaseOperatonsProvider = null;
            mockedDbContextSaveChanges = null;
        }
    }
}
