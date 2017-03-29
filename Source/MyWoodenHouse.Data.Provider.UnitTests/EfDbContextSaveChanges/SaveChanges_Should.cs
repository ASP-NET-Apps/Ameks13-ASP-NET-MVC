using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Provider.UnitTests.EfDbContextSaveChangesTests
{
    [TestClass]
    public class SaveChanges_Should
    {
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
        }

        [TestMethod]
        public void VerifyThatMethodIsCalledOnce()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            EfDbContextSaveChanges actualInstance = new EfDbContextSaveChanges(mockedMyWoodenHouseDbContext.Object);
            int _ = actualInstance.SaveChanges();

            // Assert
            mockedMyWoodenHouseDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ReturnResultOfType_Int_WhenCalled()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            EfDbContextSaveChanges actualInstance = new EfDbContextSaveChanges(mockedMyWoodenHouseDbContext.Object);
            var result = actualInstance.SaveChanges();

            // Assert
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
        }
    }
}
