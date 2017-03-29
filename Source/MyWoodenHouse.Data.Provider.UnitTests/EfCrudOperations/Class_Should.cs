using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Extensions;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.Data.Provider.UnitTest.EfCrudOperationsTests
{
    [TestClass]
    public class Class_Should
    {
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        [TestInitialize]
        public void TestInit()
        {
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);
        }

        [TestMethod]
        public void HasProperty_Context()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("Context"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_Categories()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance.Context, typeof(IMyWoodenHouseDbContext));
        }
        
        [TestMethod]
        public void HasProperty_DbSet()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("DbSet"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_DbSet()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance.DbSet, typeof(IDbSet<Category>));
        }

        [TestMethod]
        public void HasProperty_All()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("All"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_All()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance.All, typeof(IQueryable<Category>));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
        }
    }
}
