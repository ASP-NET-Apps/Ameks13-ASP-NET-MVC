using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Services.UnitTest.CategoryServiceTests
{
    [TestClass]
    public class DeleteCategoryById_Should
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
        public void VerifyMethodIsCalledOnce_Delete()
        {
            // Arrange
            int id = 1;
            string username = "user";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            actualService.Delete(id, username);

            // Assert
            mockedCategoryBaseOperatonsProvider.Verify(m => m.Delete(It.IsAny<int?>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_SaveChanges()
        {
            // Arrange
            int id = 1;
            string username = "user";

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            actualService.Delete(id, username);

            // Assert
            mockedDbContextSaveChanges.Verify(m => m.SaveChanges(), Times.Once);
        }

        //[TestMethod]
        //public void ThrowArgumentNullException_WhenArgumentIsNull_Id()
        //{
        //    // Arrange
        //    string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, "null");

        //    // Act
        //    CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

        //    // Assert

        //    Assert.ThrowsException<ArgumentNullException>(() => actualService.Delete(null), errorMessage);
        //}

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNotValid_Id()
        {
            // Arrange
            int id = -1;
            string username = "user";
            string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter, id);

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => actualService.Delete(id, username), errorMessage);
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
