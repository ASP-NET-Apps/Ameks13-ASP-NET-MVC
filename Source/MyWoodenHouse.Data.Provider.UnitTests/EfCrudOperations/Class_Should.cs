using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Models;
using MyWoodenHouse.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.Data.Provider.UnitTest.EfCrudOperationsTests
{
    [TestClass]
    public class Class_Should
    {
        private static Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        [TestInitialize]
        public void TestInit()
        {
            mockedMyWoodenHouseDbContext = new Mock<MyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);
        }

        [TestMethod]
        public void ImplementInterface_IEfCrudOperatonsOfCategory()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsNotNull(typeof(EfCrudOperatons<Category>).GetInterfaces().SingleOrDefault(i => i == typeof(IEfCrudOperatons<Category>)));
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
        public void HasPropertyOfCorrectType_Context()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            var actualInstance = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.IsInstanceOfType(actualInstance.Context, typeof(MyWoodenHouseDbContext));
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
