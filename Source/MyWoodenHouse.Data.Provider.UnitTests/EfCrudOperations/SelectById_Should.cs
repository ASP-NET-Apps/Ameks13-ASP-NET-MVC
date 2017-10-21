using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.Data.Provider.UnitTest.EfCrudOperationsTests
{
    [TestClass]
    public class SelectById_Should
    {
        private static Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;
        private static IQueryable<Category> fakeData;

        [TestInitialize]
        public void TestInitialize()
        {
            mockedMyWoodenHouseDbContext = new Mock<MyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();
            
            fakeData = new List<Category> {
                new Category { Id = 1, Name = "House" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 3, Name = "Cabin" },
                new Category { Id = 4, Name = "Bungalow" }
            }.AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedDbSet.Setup(m => m.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => fakeData.FirstOrDefault(d => d.Id == (int)ids[0]));


            mockedMyWoodenHouseDbContext.Setup(c => c.Set<Category>()).Returns(mockedDbSet.Object);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCalledNullableId()
        {
            // Arrange
            // Done in the TestInitialize method

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            string errorMessage = Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithNotNullableParameter;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.SelectById(null), errorMessage);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenCalledNegativeId()
        {
            // Arrange
            // Done in the TestInitialize method

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            string errorMessage = Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter;

            // Assert
            Assert.ThrowsException<ArgumentException>(() => actualService.SelectById(-1), errorMessage);
        }

        [TestMethod]
        public void ReturnCorrectObjectType_WhenCalledWithValidAndExistingId()
        {
            // Arrange
            // Done in the TestInitialize method

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualCategory = actualService.SelectById(1);

            // Assert
            Assert.IsInstanceOfType(actualCategory, typeof(Category));
        }
        
        [TestMethod]
        public void CallDbSetMethodFindOnce_WhenCalledWithValidParameter()
        {
            // Arrange
            // Done in the TestInitialize method

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualCategory = actualService.SelectById(1);

            // Assert
            mockedDbSet.Verify(c => c.Find(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void ReturnTheSearchedCategoryWithProperId_WhenCalledWithValidParameter()
        {
            // Arrange
            int searchedId = 1;

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualCategory = actualService.SelectById(searchedId);
            var mockedCategory = fakeData.FirstOrDefault(c => c.Id == searchedId);

            // Assert
            Assert.AreSame(mockedCategory, actualCategory);
        }

        [TestMethod]
        public void ReturnTheSearchedCategoryWithProperIdAgain_WhenCalledWithValidParameter()
        {
            // Arrange
            int searchedId = 3;

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualCategory = actualService.SelectById(searchedId);
            var mockedCategory = fakeData.FirstOrDefault(c => c.Id == searchedId);

            // Assert
            Assert.AreSame(mockedCategory, actualCategory);
        }

        [TestMethod]
        public void ReturnNullWithNotExistingInTheCollectionId_WhenCalledWithValidParameter()
        {
            // Arrange
            int notExistingId = 5;

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var actualCategory = actualService.SelectById(notExistingId);

            // Assert
            Assert.AreSame(null, actualCategory);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
            fakeData = null;
        }
    }
}
