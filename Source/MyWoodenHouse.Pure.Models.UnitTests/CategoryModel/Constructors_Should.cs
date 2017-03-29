using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWoodenHouse.Extensions;
using MyWoodenHouse.Pure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Pure.Models.UnitTests.CategoryModelTests
{
    [TestClass]
    public class Constructors_Should
    {
        [TestMethod]
        public void BePublic()
        {
            // Arrange & Act
            bool hasPublicConstructors = typeof(CategoryModel).HasPublicConstructor();

            // Assert
            Assert.IsTrue(hasPublicConstructors);
        }

        [TestMethod]
        public void HaveEmptyConstructorAndReturnCorrectInstance_CategoryModel()
        {
            // Arrange & Act
            var actualInstance = new CategoryModel();

            // Assert
            Assert.IsInstanceOfType(actualInstance, typeof(CategoryModel));
        }
    }
}
