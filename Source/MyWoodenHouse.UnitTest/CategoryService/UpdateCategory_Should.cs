using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Pure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.UnitTest.CategoryServiceTests
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
        public void UpdateTheItemSpecifiedInTheInputParameter_WhenCalledWithValidArgument_CategoryModel()
        {
            // Arrange
            Category categoryUnapdated = fakeData.FirstOrDefault(item => item.Id == 4);
            CategoryModel categoryToUpdate = new CategoryModel(categoryUnapdated);
            categoryToUpdate.Name = "This Name is changed";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            CategoryModel updatedCategoryModel = actualService.UpdateCategory(categoryToUpdate);

            // Assert
            Assert.AreSame(categoryToUpdate, updatedCategoryModel);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_Update()
        {
            // Arrange
            Category categoryUnapdated = fakeData.FirstOrDefault(item => item.Id == 4);
            CategoryModel categoryToUpdate = new CategoryModel(categoryUnapdated);
            categoryToUpdate.Name = "This Name is changed";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            CategoryModel updatedCategoryModel = actualService.UpdateCategory(categoryToUpdate);

            // Assert
            mockedCategoryBaseOperatonsProvider.Verify(m => m.Update(It.IsAny<Category>()), Times.Once);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_SaveChanges()
        {
            // Arrange
            Category categoryUnapdated = fakeData.FirstOrDefault(item => item.Id == 4);
            CategoryModel categoryToUpdate = new CategoryModel(categoryUnapdated);
            categoryToUpdate.Name = "This Name is changed";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            CategoryModel updatedCategoryModel = actualService.UpdateCategory(categoryToUpdate);

            // Assert
            mockedDbContextSaveChanges.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull_CategoryModel()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.UpdateCategory(null));
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
