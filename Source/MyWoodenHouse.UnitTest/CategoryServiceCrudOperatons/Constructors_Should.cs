using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Data.Provider.Contracts;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using MyWoodenHouse.Data.Models;

namespace MyWoodenHouse.UnitTest.CategoryServiceCrudOperatonsTests
{
    [TestClass]
    public class Constructors_Should
    {
        //global for the test run
        private static TestContext context;
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {   
            // Default stuff
            context = testContext;

            // Arrange
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Cleanup
            mockedMyWoodenHouseDbContext = null;
        }

        [TestMethod]
        public void BePublic()
        {
            // TODO
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentDbContextIsNull()
        {
            // Arrange & Act &  Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CategoryServiceCrudOperatons(null));
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
    }
}
