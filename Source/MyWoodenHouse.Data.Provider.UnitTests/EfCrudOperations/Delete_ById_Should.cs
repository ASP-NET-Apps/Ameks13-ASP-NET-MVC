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
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Provider.UnitTest.EfCrudOperationsTests
{
    [TestClass]
    public class Delete_ById_Should
    {
        private static Mock<MyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;
        private static IList<Category> fakeData;

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
            };

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.AsQueryable().Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.AsQueryable().Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.AsQueryable().ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.AsQueryable().GetEnumerator());

            mockedDbSet.Setup(m => m.Remove(It.IsAny<Category>()))
                .Callback<Category>(c => fakeData.Remove(c));
            mockedDbSet.Setup(m => m.Find(It.IsAny<int>()))
               .Returns<object[]>(ids => fakeData.FirstOrDefault(d => d.Id == (int)ids[0]));

            mockedMyWoodenHouseDbContext.Setup(c => c.Set<Category>()).Returns(mockedDbSet.Object);
        }

        [TestMethod]
        public void DeleteTheCorrectItem_WhenCalledWithValidAndExistingArgument_Id()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(c => c.GetEntityState(It.IsAny<Category>()))
                .Returns(() => EntityState.Deleted);
            int id = 1;

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var categoryToDelete = actualService.SelectById(id);
            actualService.Delete(categoryToDelete);

            // Assert
            Assert.AreSame(null, actualService.SelectById(id));
        }

        [TestMethod]
        public void DeleteOnyOneItem_WhenCalledWithValidAndExistingArgument_Id()
        {
            // Arrange
            mockedMyWoodenHouseDbContext.Setup(c => c.GetEntityState(It.IsAny<Category>()))
                .Returns(() => EntityState.Deleted);
            int id = 1;

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            var categoryToDelete = actualService.SelectById(id);
            var countCategoriesBeforeDelete = fakeData.Count;
            actualService.Delete(categoryToDelete);

            // Assert
            Assert.AreEqual(countCategoriesBeforeDelete - 1, fakeData.Count);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull_Id()
        {
            // Arrange   
            int? id = null;
            string username = "user";
            string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithNotNullableParameter);

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => actualService.Delete(id, username), errorMessage);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenArgumentIsNotValid_Id()
        {
            // Arrange
            int id = -1;
            string username = "user";
            string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, id);

            // Act
            var actualService = new EfCrudOperatons<Category>(mockedMyWoodenHouseDbContext.Object);
            
            // Assert
            Assert.ThrowsException<ArgumentException>(() => actualService.Delete(id, username), errorMessage);
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
