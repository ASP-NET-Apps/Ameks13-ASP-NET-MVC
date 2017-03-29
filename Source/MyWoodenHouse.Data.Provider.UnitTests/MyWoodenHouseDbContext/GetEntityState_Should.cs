using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Ef.Models;
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
            Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            var actualEntityState = mockedMyWoodenHouseDbContext.Object.GetEntityState(new Category());
            
            // Assert
            mockedMyWoodenHouseDbContext.Verify(m => m.GetEntityState(It.IsAny<object>()), Times.Once);
        }

        [TestMethod]
        public void ReturnsCorrectInstance_EntityState()
        {
            // Arrange & Act
            Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            var actualEntityState = mockedMyWoodenHouseDbContext.Object.GetEntityState(new Category());

            // Assert
            Assert.IsInstanceOfType(actualEntityState, typeof(EntityState));
        }
    }
}
