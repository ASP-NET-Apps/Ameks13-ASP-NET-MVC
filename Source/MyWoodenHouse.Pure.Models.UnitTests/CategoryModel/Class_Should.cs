using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWoodenHouse.Contracts.PureModels;
using MyWoodenHouse.Contracts;
using MyWoodenHouse.Extensions;

namespace MyWoodenHouse.Pure.Models.UnitTests.CategoryModelTests
{
    [TestClass]
    public class Class_Should
    {
        [TestMethod]
        public void ImplementInterface_ICategoryModel()
        {
            // Arrange & Act
            CategoryModel actualInstance = new CategoryModel();
            ICategoryModel actualInstanceInterface = actualInstance as ICategoryModel;

            // Assert
            Assert.IsNotNull(actualInstanceInterface);
        }

        [TestMethod]
        public void ImplementInterface_IHasIntId()
        {
            // Arrange & Act
            CategoryModel actualInstance = new CategoryModel();
            IHasIntId actualInstanceInterface = actualInstance as IHasIntId;

            // Assert
            Assert.IsNotNull(actualInstanceInterface);
        }

        [TestMethod]
        public void HasProperty_Id()
        {
            // Arrange & Act
            CategoryModel actualInstance = new CategoryModel();

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("Id"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_Id()
        {
            // Arrange & Act
            CategoryModel actualInstance = new CategoryModel();

            // Assert
            Assert.IsInstanceOfType(actualInstance.Id, typeof(int));
        }

        [TestMethod]
        public void HasProperty_Name()
        {
            // Arrange & Act
            CategoryModel actualInstance = new CategoryModel();

            // Assert
            Assert.IsTrue(actualInstance.HasProperty("Name"));
        }

        [TestMethod]
        public void HasPropertyOfCorrectType_Name()
        {
            // Arrange & Act
            CategoryModel actualInstance = new CategoryModel();

            // Assert
            Assert.IsInstanceOfType(actualInstance.Name, typeof(string));
        }
    }
}
