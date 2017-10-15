using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Extensions;
using System;

namespace MyWoodenHouse.Data.Provider.UnitTests.EfDbContextSaveChangesTests
{
    [TestClass]
    public class Constructors_Should
    {
        private static Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedMyWoodenHouseDbContext = new Mock<MyWoodenHouseDbContext>();
        }

        [TestMethod]
        public void BePublic()
        {
            // Arrange & Act
            bool hasPublicConstructors = typeof(EfDbContextSaveChanges).HasPublicConstructor();

            // Assert
            Assert.IsTrue(hasPublicConstructors);
        }

        [TestMethod]
        public void CreateValidInstance_EfDbContextSaveChanges_WhenCalledWithValidArgument()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfDbContextSaveChanges(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance, typeof(EfDbContextSaveChanges));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentDbContextIsNull()
        {
            // Arrange
            string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "EfDbContextSaveChanges");

            // Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EfDbContextSaveChanges(null), errorMessage);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
        }
    }
}
