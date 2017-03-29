using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Ef.Models;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider.UnitTests.MyWoodenHouseDbContextTests
{
    [TestClass]
    public class SetEntityState_Should
    {
        [TestMethod]
        public void ExistsAndCanBeCalled()
        {
            // Arrange & Act
            Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedMyWoodenHouseDbContext.Object.SetEntityState(new Category(), EntityState.Modified);

            // Assert
            mockedMyWoodenHouseDbContext.Verify(m => m.SetEntityState(It.IsAny<object>(), It.IsAny<EntityState>()), Times.Once);
        }
    }
}
