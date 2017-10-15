using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Pure.Models.UnitTests.CategoryTests
{
    [TestClass]
    public class Constructors_Should
    {
        [TestMethod]
        public void BePublic()
        {
            // Arrange & Act
            bool hasPublicConstructors = typeof(Category).HasPublicConstructor();

            // Assert
            Assert.IsTrue(hasPublicConstructors);
        }

        [TestMethod]
        public void HaveEmptyConstructorAndReturnCorrectInstance_Category()
        {
            // Arrange & Act
            var actualInstance = new Category();

            // Assert
            Assert.IsInstanceOfType(actualInstance, typeof(Category));
        }
    }
}
