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
    public class GetAllCategoriesSortedByName_Should
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
                    new Category { Id = 4, Name = "D" },
                    new Category { Id = 2, Name = "B" },
                    new Category { Id = 1, Name = "A" },
                    new Category { Id = 3, Name = "C" }
                }.AsQueryable();

            mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);
        }

        [TestMethod]
        public void ReturnAllCategoriesOrderedByName_WhenExecuted()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            CategoryService actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            List<CategoryModel> actualCategories = actualInstance.GetAllCategoriesSortedByName().ToList();
            string[] orderedNames = new string[] { "A", "B", "C", "D" };

            // Assert
            for (int i = 0; i < orderedNames.Length; i++)
            {
                Assert.AreEqual(orderedNames[i], actualCategories[i].Name);
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
