using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Contracts;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Extensions;
using System;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider.UnitTest.EfCrudOperationsTests
{
    [TestClass]
    public class Constructors_Should
    {
        private static Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedMyWoodenHouseDbContext = new Mock<MyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();
        }

        [TestMethod]
        public void BePublic()
        {
            // Arrange & Act
            bool hasPublicConstructors = typeof(EfCrudOperatons<Category>).HasPublicConstructor();

            // Assert
            Assert.IsTrue(hasPublicConstructors);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentDbContextIsNull()
        {
            // Arrange & Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EfCrudOperatons<Category>(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenDbSetIsNull()
        {
            // Arrange
            DbSet<Category> nullDbSet = null;
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(nullDbSet);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object));
        }

        [TestMethod]
        public void InvokeDbContextSetMethodTwice_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            // Second call is used by the Identity because using the same dbContext
            // app.CreatePerOwinContext(MyWoodenHouseDbContext.Create)
            //mockedMyWoodenHouseDbContext.Verify(mock => mock.Set<Category>(), Times.Once);
            mockedMyWoodenHouseDbContext.Verify(mock => mock.Set<Category>(), Times.Exactly(2));
        }

        [TestMethod]
        public void ProvideAccessToTheInjectedDbContext_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.AreSame(mockedMyWoodenHouseDbContext.Object, actualInstance.Context);
        }

        [TestMethod]
        public void CreateCategoryDbSet_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.AreSame(mockedDbSet.Object, actualInstance.DbSet);
        }

        [TestMethod]
        public void CreateValidEfCrudOperatonsInstance_WhenArgumentDbContextIsValid()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance, typeof(EfCrudOperatons<Category>));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
        }
    }
}
