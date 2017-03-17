using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.UnitTest.CategoryServiceCrudOperatonsTests
{
    [TestClass]
    public class SelectById_Should
    {
        private static Mock<IMyWoodenHouseDbContext> mockedMyWoodenHouseDbContext;
        private static Mock<DbSet<Category>> mockedDbSet;

        // TODO Research isue
        // ClassInitialize works in Visual Studio 2015 but 
        // causes Error when triggered inside Jenkins ?!
        //[ClassInitialize]
        //public static void ClassInitialize(TestContext testContext)
        //{
        //    mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
        //    mockedDbSet = new Mock<DbSet<Category>>();
        //}

        [TestInitialize]
        public void TestInitialize()
        {
            mockedMyWoodenHouseDbContext = new Mock<IMyWoodenHouseDbContext>();
            mockedDbSet = new Mock<DbSet<Category>>();
        }


        [TestMethod]
        public void ReturnCorrectObjectType_WhenCalled()
        {
            // Arrange
            var fakeData = new List<Category>().AsQueryable();
            //fakeData.Add(new Mock<Category>().Object);

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(c => c.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var actualCategories = actualService.Select();

            // Assert
            Assert.IsInstanceOfType(actualCategories, typeof(IEnumerable<Category>));
        }

        // TODO Investigate or delete
        //[TestMethod]
        //public void BeExecutedOnce_WhenCalled()
        //{
        //    // Arrange
        //    var fakeData = new List<Category>().AsQueryable();
        //    //fakeData.Add(new Mock<Category>().Object);

        //    mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
        //    mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
        //    mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
        //    mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

        //    mockedMyWoodenHouseDbContext.Setup(c => c.Set<Category>()).Returns(mockedDbSet.Object);

        //    // Act
        //    var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
        //    var actualCategories = actualService.Get();

        //    // Assert
        //    mockedDbSet.Verify(c => c.Select(It.IsAny<Func<Category, int>>()), Times.Once );
        //}

        [TestMethod]
        public void ReturnZeroCategories_WhenZeroCategoriesInside()
        {
            // Arrange
            var fakeData = new List<Category>().AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(mock => mock.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var actualCategories = actualService.Select();

            // Assert
            Assert.AreEqual(0, actualCategories.Count());
        }

        [TestMethod]
        public void ReturnFourCategories_WhenTheyAreFourCategoriesInside()
        {
            // Arrange
            var fakeData = new List<Category> {
                new Category { Name = "House" },
                new Category { Name = "Garage" },
                new Category { Name = "Cabin" },
                new Category { Name = "Bungalow" }
            }.AsQueryable();

            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(fakeData.Provider);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(fakeData.Expression);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(fakeData.ElementType);
            mockedDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(fakeData.GetEnumerator());

            mockedMyWoodenHouseDbContext.Setup(c => c.Set<Category>()).Returns(mockedDbSet.Object);

            // Act
            var actualService = new CategoryServiceCrudOperatons(mockedMyWoodenHouseDbContext.Object);
            var actualCategories = actualService.Select();

            // Assert
            Assert.AreEqual(4, actualCategories.Count());
        }

        // TODO Research isue
        // ClassInitialize works in Visual Studio 2015 but 
        // causes Error when triggered inside Jenkins ?!
        //[ClassCleanup]
        //public static void ClassCleanup()
        //{
        //    mockedMyWoodenHouseDbContext = null;
        //    mockedDbSet = null;
        //}

        [TestCleanup]
        public void TestCleanup()
        {
            mockedMyWoodenHouseDbContext = null;
            mockedDbSet = null;
        }
    }
}
