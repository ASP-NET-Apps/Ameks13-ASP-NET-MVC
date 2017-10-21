using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Models;
using MyWoodenHouse.Extensions;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider.UnitTests.MyWoodenHouseDbContextTests
{
    [TestClass]
    public class Class_Should
    {
        [TestMethod]
        public void ImplementInterface()
        {
            // Arrange & Act
            MyWoodenHouseDbContext actualInstance = new MyWoodenHouseDbContext();
            MyWoodenHouseDbContext actualInstanceInterface = actualInstance as MyWoodenHouseDbContext;

            // Assert
            //Assert.IsNotNull(actualInstanceInterface);
        }

        [TestMethod]
        public void HasProperty_Categories()
        {
            // Arrange & Act
            MyWoodenHouseDbContext actualInstance = new MyWoodenHouseDbContext();

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("Categories"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_Categories()
        {
            // Arrange & Act
            MyWoodenHouseDbContext actualInstance = new MyWoodenHouseDbContext();

            // Assert
            Assert.IsInstanceOfType(actualInstance.Categories, typeof(IDbSet<Category>));
        }
    }
}
