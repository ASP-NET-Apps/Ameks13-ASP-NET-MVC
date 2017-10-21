using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWoodenHouse.Extensions;
using MyWoodenHouse.Models;
using MyWoodenHouse.Models.Contracts;

namespace MyWoodenHouse.Pure.Models.UnitTests.CategoryTests
{
    [TestClass]
    public class Class_Should
    {
        [TestMethod]
        public void ImplementInterface_ICategory()
        {
            // Arrange & Act
            Category actualInstance = new Category();
            ICategory actualInstanceInterface = actualInstance as ICategory;

            // Assert
            Assert.IsNotNull(actualInstanceInterface);
        }

        [TestMethod]
        public void ImplementInterface_IHasIntId()
        {
            // Arrange & Act
            Category actualInstance = new Category();
            IHasIntId actualInstanceInterface = actualInstance as IHasIntId;

            // Assert
            Assert.IsNotNull(actualInstanceInterface);
        }

        [TestMethod]
        public void HasProperty_Id()
        {
            // Arrange & Act
            Category actualInstance = new Category();

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("Id"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_Id()
        {
            // Arrange & Act
            Category actualInstance = new Category();

            // Assert
            Assert.IsInstanceOfType(actualInstance.Id, typeof(int));
        }

        [TestMethod]
        public void HasProperty_Name()
        {
            // Arrange & Act
            Category actualInstance = new Category();

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("Name"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_Name()
        {
            // Arrange & Act
            Category actualInstance = new Category();

            // Assert
            Assert.IsInstanceOfType(actualInstance.Name, typeof(string));
        }
    }
}
