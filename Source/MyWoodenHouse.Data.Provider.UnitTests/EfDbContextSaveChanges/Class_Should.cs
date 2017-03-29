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
    public class Class_Should
    {
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;

        [TestInitialize]
        public void TestInit()
        {
            // Arrange
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
        }

        [TestMethod]
        public void ImplementInterface()
        {
            // Arrange
            // Done in the TestInit method

            // Act
            EfDbContextSaveChanges actualInstance = new EfDbContextSaveChanges(mockedMyWoodenHouseDbContext.Object);
            IEfDbContextSaveChanges actualInstanceInterface = actualInstance as IEfDbContextSaveChanges;

            // Assert
            Assert.IsNotNull(actualInstanceInterface);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
        }
    }
}
