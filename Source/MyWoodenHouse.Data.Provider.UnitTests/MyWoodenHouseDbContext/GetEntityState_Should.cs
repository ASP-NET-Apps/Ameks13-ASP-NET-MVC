using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Models;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider.UnitTests.MyWoodenHouseDbContextTests
{
    [TestClass]
    public class GetEntityState_Should
    {
        [TestMethod]
        public void ExistsAndCanBeCalled()
        {
            // Arrange & Act
            Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext = new Mock<MyWoodenHouseDbContext>();
            var actualEntityState = mockedMyWoodenHouseDbContext.Object.GetEntityState(new Category());
            
            // Assert
            mockedMyWoodenHouseDbContext.Verify(m => m.GetEntityState(It.IsAny<object>()), Times.Once);
        }

        [TestMethod]
        public void ReturnsCorrectInstance_EntityState()
        {
            // Arrange & Act
            Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext = new Mock<MyWoodenHouseDbContext>();
            var actualEntityState = mockedMyWoodenHouseDbContext.Object.GetEntityState(new Category());

            // Assert
            Assert.IsInstanceOfType(actualEntityState, typeof(EntityState));
        }
    }
}
