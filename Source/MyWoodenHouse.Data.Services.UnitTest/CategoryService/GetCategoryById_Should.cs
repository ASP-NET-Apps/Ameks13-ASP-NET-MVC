using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services.UnitTest.CategoryServiceTests
{
    [TestClass]
    public class GetCategoryById_Should
    {
        private static Mock<IEfCrudOperatons<Category>> mockedCategoryBaseOperatonsProvider;
        private static Mock<IEfDbContextSaveChanges> mockedDbContextSaveChanges;
        private static IQueryable<Category> fakeData;

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
            }.AsQueryable();

            mockedCategoryBaseOperatonsProvider.Setup(m => m.SelectById(It.IsAny<int?>()))
                .Returns<object>(ids => fakeData.FirstOrDefault(c => c.Id == (int?)ids));
        }

        [TestMethod]
        public void ReturnCategoryWithMatchingId_WhenCalledWithValidAndExistingIdParameter()
        {
            // Arrange
            int searchedId = 1;

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            Category actualCategory = actualService.GetById(searchedId);

            Category mockedCategory = fakeData.FirstOrDefault(c => c.Id == searchedId);
            //Category mockedCategory = new Category(mockedCategory);

            // Assert
            Assert.AreEqual(mockedCategory.Id, actualCategory.Id);
            Assert.AreEqual(mockedCategory.Name, actualCategory.Name);
        }

        [TestMethod]
        public void ReturnCategoryWithMatchingIdAgain_WhenCalledWithValidAndExistingIdParameter()
        {
            // Arrange
            int searchedId = 3;

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            Category actualCategory = actualService.GetById(searchedId);

            Category mockedCategory = fakeData.FirstOrDefault(c => c.Id == searchedId);
            //Category mockedCategory = new Category(mockedCategory);

            // Assert
            Assert.AreEqual(mockedCategory.Id, actualCategory.Id);
            Assert.AreEqual(mockedCategory.Name, actualCategory.Name);
        }

        [TestMethod]
        public void VerifyMethodIsCalledOnce_GetCategoryById()
        {
            // Arrange
            int searchedId = 1;

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            Category actualCategory = actualService.GetById(searchedId);

            // Assert
            mockedCategoryBaseOperatonsProvider.Verify(m => m.SelectById(It.IsAny<int?>()), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull_Id()
        {
            // Arrange            
            string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithNotNullableParameter, "null");

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.GetById(null), errorMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNotValid_Id()
        {
            // Arrange
            int searchedId = -1;
            string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter, searchedId);

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => actualService.GetById(searchedId), errorMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCalledWithValidButNotExistingInTheCollectionArgument_Id()
        {
            // Arrange
            int searchedId = 5;
            string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Category", searchedId);

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.GetById(searchedId), errorMessage);
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
