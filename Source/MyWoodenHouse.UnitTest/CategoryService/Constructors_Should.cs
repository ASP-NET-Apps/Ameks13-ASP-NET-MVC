using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.UnitTest.CategoryServiceTests
{
    [TestClass]
    public class Constructors_Should
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
        public void ReturnCategoryServiceInstance_WhenAllArgumentAreValid()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new CategoryService(mockedCategoryBaseOperatonsProvider.Object, mockedDbContextSaveChanges.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance, typeof(CategoryService));
        }

        [TestMethod]
        public void BePublic()
        {
            // Arrange 
            // Done in the TestInit method

            // Act
            bool hasPublicConstructors = typeof(CategoryService).HasPublicConstructor();

            // Assert
            Assert.IsTrue(hasPublicConstructors);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull_CategoryBaseOperatonsProvider()
        {
            // Arrange 
            string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Category>", "CategoryService");

            // Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => new  CategoryService(null, mockedDbContextSaveChanges.Object), errorMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull_DbContextSaveChanges()
        {
            // Arrange 
            string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "CategoryService");

            // Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CategoryService(mockedCategoryBaseOperatonsProvider.Object, null), errorMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenAllArgumentsAreNull()
        {
            // Arrange 
            string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Category> and EfDbContextSaveChanges", "CategoryService");

            // Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CategoryService(null, null), errorMessage);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedCategoryBaseOperatonsProvider = null;
            mockedDbContextSaveChanges = null;
        }
    }
}
