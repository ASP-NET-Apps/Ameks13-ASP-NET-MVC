using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Pure.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.UnitTest.CategoryServiceTests
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
            int searchedId = 3;

            // Act
            CategoryService actualService = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            CategoryModel actualCategoryModel = actualService.GetCategoryById(searchedId);

            Category mockedCategory = fakeData.FirstOrDefault(c => c.Id == searchedId);
            CategoryModel mockedCategoryModel = new CategoryModel(mockedCategory);

            // Assert
            Assert.AreEqual(mockedCategoryModel.Id, actualCategoryModel.Id);
            Assert.AreEqual(mockedCategoryModel.Name, actualCategoryModel.Name);
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
