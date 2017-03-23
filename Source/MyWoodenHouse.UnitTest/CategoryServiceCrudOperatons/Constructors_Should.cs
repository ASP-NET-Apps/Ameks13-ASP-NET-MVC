using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Extensions;
using System;
using System.Data.Entity;

namespace MyWoodenHouse.UnitTest.CategoryServiceCrudOperatonsTests
{
    [TestClass]
    public class Constructors_Should
    {
        //global for the test run
        //private static TestContext context;

        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        //[ClassInitialize]
        //public static void ClassInit(TestContext testContext)
        //{   
        //    // Default class context
        //    context = testContext;

        //    // Arrange
        //    //mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
        //    //mockedDbSet = new Mock<DbSet<Category>>();
        //}

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();
        }

        [TestMethod]
        public void BePublic()
        {
            // Arrange & Act
            bool hasPublicConstructors = typeof(CategoryServiceCrudOperatons).HasPublicConstructor();

            // Assert
            Assert.IsTrue(hasPublicConstructors);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentDbContextIsNull()
        {
            // Arrange & Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CategoryServiceCrudOperatons(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenDbSetIsNull()
        {
            // Arrange
            DbSet<Category> nullDbSet = null;
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(nullDbSet);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object));
        }

        [TestMethod]
        public void InvokeDbContextSetMethodOnce_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);

            // Assert
            mockedMyWoodenHouseDbContext.Verify(mock => mock.Set<Category>(), Times.Once);
        }

        [TestMethod]
        public void ProvideAccessToTheInjectedDbContext_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            
            // Assert
            Assert.AreSame(mockedMyWoodenHouseDbContext.Object, actualInstance.Context);
        }

        [TestMethod]
        public void CreateCategoryDbSet_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            
            // Assert
            Assert.AreSame(mockedDbSet.Object, actualInstance.CategoryDbSet);
        }

        [TestMethod]
        public void CreateValidCategoryServiceCrudOperatonsInstance_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance, typeof(CategoryServiceCrudOperatons));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
        }

        //[ClassCleanup()]
        //public static void ClassCleanup()
        //{
        //    // Cleanup
        //    //mockedMyWoodenHouseDbContext = null;
        //    //mockedDbSet = null;
        //}
    }
}
