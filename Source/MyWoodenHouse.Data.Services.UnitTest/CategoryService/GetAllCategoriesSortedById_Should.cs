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

namespace MyWoodenHouse.Data.Services.UnitTest.CategoryServiceTests
{
    [TestClass]
    public class GetAllCategoriesSortedById_Should
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
                new Category { Id = 4, Name = "Bungalow" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 1, Name = "House" },
                new Category { Id = 3, Name = "Cabin" }
            }.AsQueryable();

            mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);
        }

        [TestMethod]
        public void ReturnAllCategoriesOrderedById_WhenExecuted()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            CategoryService actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            List<CategoryModel> actualCategories = actualInstance.GetAllCategoriesSortedById().ToList();
            int[] orderedIds = new int[] { 1, 2, 3, 4 };

            // Assert
            for (int i = 0; i < orderedIds.Length; i++)
            {
                Assert.AreEqual(orderedIds[i], actualCategories[i].Id);
            }
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
