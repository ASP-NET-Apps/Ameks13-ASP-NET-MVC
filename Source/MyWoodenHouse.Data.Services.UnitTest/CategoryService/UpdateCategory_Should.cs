using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services.UnitTest.CategoryServiceTests
{
    [TestClass]
    public class UpdateCategory_Should
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

        }

        [TestMethod]
        public void UpdateTheItemSpecifiedInTheInputParameter_WhenCalledWithValidArgument_Category()
        {
            // Arrange
            Category categoryToUpdate = fakeData.FirstOrDefault(item => item.Id == 4);
            //Category categoryToUpdate = new Category(categoryUnapdated);
            categoryToUpdate.Name = "This Name is changed";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            Category updatedCategory = actualService.Update(categoryToUpdate);

            // Assert
            Assert.AreSame(categoryToUpdate, updatedCategory);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_Update()
        {
            // Arrange
            Category categoryToUpdate = fakeData.FirstOrDefault(item => item.Id == 4);
            //Category categoryToUpdate = new Category(categoryUnapdated);
            categoryToUpdate.Name = "This Name is changed";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            Category updatedCategory = actualService.Update(categoryToUpdate);

            // Assert
            mockedCategoryBaseOperatonsProvider.Verify(m => m.Update(It.IsAny<Category>()), Times.Once);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_SaveChanges()
        {
            // Arrange
            Category categoryToUpdate = fakeData.FirstOrDefault(item => item.Id == 4);
            //Category categoryToUpdate = new Category(categoryUnapdated);
            categoryToUpdate.Name = "This Name is changed";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            Category updatedCategory = actualService.Update(categoryToUpdate);

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
            Assert.ThrowsException<ArgumentNullException>(() => actualService.Update(null));
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
