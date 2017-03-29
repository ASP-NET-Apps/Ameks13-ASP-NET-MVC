using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWoodenHouse.Extensions;

namespace MyWoodenHouse.Data.Provider.UnitTests.MyWoodenHouseDbContextTests
{
    [TestClass]
    public class Constructors_Should
    {
        [TestMethod]
        public void BePublic()
        {
            // Arrange & Act
            bool hasPublicConstructors = typeof(MyWoodenHouseDbContext).HasPublicConstructor();

            // Assert
            Assert.IsTrue(hasPublicConstructors);
        }
    }
}
