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
    public class GetAllCategories_Should
    {
        private static Mock<IEfCrudOperatons<Category>> mockedCategoryBaseOperatonsProvider;
        private static Mock<IEfDbContextSaveChanges> mockedDbContextSaveChanges;
        //private static IQueryable<Category> fakeData;

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedCategoryBaseOperatonsProvider = new Mock<IEfCrudOperatons<Category>>();
            mockedDbContextSaveChanges = new Mock<IEfDbContextSaveChanges>();

            //fakeData = new List<Category> {
            //    new Category { Id = 1, Name = "House" },
            //    new Category { Id = 2, Name = "Garage" },
            //    new Category { Id = 3, Name = "Cabin" },
            //    new Category { Id = 4, Name = "Bungalow" }
            //}.AsQueryable();

            //mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            //mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            //mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            //mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            //mockedDbSet.Setup(m => m.Find(It.IsAny<int>()))
            //    .Returns<object[]>(ids => fakeData.FirstOrDefault(d => d.Id == (int)ids[0]));


            //mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);
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
            IEnumerable<CategoryModel> actualCategories = actualInstance.GetAllCategories();

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
            Assert.ThrowsException<ArgumentNullException>(() => actualInstance.GetAllCategories());
        }

        [TestMethod]
        public void ReturnNull_WhenThereAreNocategoriesInTheCollection()
        {
            // Arrange
            IQueryable<Category> fakeData = new List<Category>().AsQueryable();
            mockedCategoryBaseOperatonsProvider.Setup(c => c.All).Returns(fakeData);

            // Act
            CategoryService actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);
            IEnumerable<CategoryModel> actualCategories = actualInstance.GetAllCategories();

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
            IEnumerable<CategoryModel> actualCategories = actualInstance.GetAllCategories();

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
