using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services.UnitTest.CategoryServiceTests
{
    [TestClass]
    public class InsertCategory_Should
    {
        private static Mock<IEfCrudOperatons<Category>> mockedCategoryBaseOperatonsProvider;
        private static Mock<IEfDbContextSaveChanges> mockedDbContextSaveChanges;
        private static IList<Category> fakeData;

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedCategoryBaseOperatonsProvider = new Mock<IEfCrudOperatons<Category>>();
            mockedDbContextSaveChanges = new Mock<IEfDbContextSaveChanges>();

            fakeData = new List<Category> {
                new Category { Id = 1, Name = "House" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 3, Name = "Cabin" },
                new Category { Id = 4, Name = "Bungalow" }
            };

            mockedCategoryBaseOperatonsProvider.Setup(m => m.Insert(It.IsAny<Category>()))
                .Callback<Category>(c => fakeData.Add(c));
        }

        [TestMethod]
        public void AddOneItemToTheCategoriesCollection_WhenCalledWithValidArgument_Category()
        {
            // Arrange
            Category categoryToAdd = new Category { Name = "The Fifth Category" };
            int perAddCategoryCount = fakeData.Count();
            
            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            int addedCategoryId = actualService.InsertCategory(categoryToAdd);

            // Assert
            Assert.AreEqual(perAddCategoryCount + 1, fakeData.Count());
        }

        [TestMethod]
        public void AddTheItemSpecifiedInTheInputParameter_WhenCalledWithValidArgument_Category()
        {
            // Arrange
            Category categoryToAdd = new Category { Name = "The Fifth Category" };
            int perAddCategoryCount = fakeData.Count();

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            int addedCategoryId = actualService.InsertCategory(categoryToAdd);
            Category addedCategoryFromFakeData = fakeData.FirstOrDefault(c => c.Id == addedCategoryId);

            // Assert
            Assert.AreEqual(categoryToAdd.Name, addedCategoryFromFakeData.Name);
        }

        [TestMethod]
        public void ReturnsTheAddedCategoryId_WhenCalledWithValidArgument_Category()
        {
            // Arrange
            Category categoryToAdd = new Category { Name = "The Fifth Category" };

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            int addedCategoryId = actualService.InsertCategory(categoryToAdd);

            // Assert
            Assert.IsTrue(addedCategoryId >= 0);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_Insert()
        {
            // Arrange
            Category categoryToAdd = new Category { Name = "The Fifth Category" };

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            int addedCategoryId = actualService.InsertCategory(categoryToAdd);

            // Assert
            mockedCategoryBaseOperatonsProvider.Verify(m => m.Insert(It.IsAny<Category>()), Times.Once);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_SaveChanges()
        {
            // Arrange
            Category categoryToAdd = new Category { Name = "The Fifth Category" };

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            int addedCategoryId = actualService.InsertCategory(categoryToAdd);

            // Assert
            mockedDbContextSaveChanges.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull_Category()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.InsertCategory(null));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedCategoryBaseOperatonsProvider = null;
            mockedDbContextSaveChanges = null;
            fakeData = null;
        }
    }
}
