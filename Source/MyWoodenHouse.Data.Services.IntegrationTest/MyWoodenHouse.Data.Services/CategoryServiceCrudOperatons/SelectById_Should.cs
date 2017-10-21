using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Data.Provider;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services;
using MyWoodenHouse.Models;
using Ninject;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyWoodenHouse.IntegrationTest.MyWoodenHouse.Data.Services.CategoryServiceCrudOperatonsTests
{
    [TestClass]
    public class SelectById_Should
    {
        private static MyWoodenHouseDbContext dbContext;
        private static DbSet<Category> dbSet;
        private static IList<Category> testData;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            //this.MyWoodenHouseDbContext = NinjectWebCommon.Kernel.Get<IMyWoodenHouseDbContext>();
            //IKernel kernel = NinjectWebCommon.Kernel;
            dbContext = NinjectWebCommon.Kernel.Get<MyWoodenHouseDbContext>();

            testData = new List<Category> {
                new Category { Id = 1, Name = "House" },
                new Category { Id = 2, Name = "Garage" },
                new Category { Id = 3, Name = "Cabin" },
                new Category { Id = 4, Name = "Bungalow" }
            };

            foreach (Category category in testData)
            {
                dbContext.Categories.Add(category);
            }
            dbContext.SaveChanges();
        }

        //[TestMethod]
        //public void ReturnCorrectObjectType_WhenCalledWithValidAndExistingId()
        //{
        //    // Arrange
        //    // In the ClassInitialize method

        //    // Act
        //    var actualService = new CategoryServiceCrudOperatons(dbContext);
        //    var actualCategory = actualService.SelectById(1);

        //    // Assert
        //    Assert.IsInstanceOfType(actualCategory, typeof(Category));
        //}

        //[TestMethod]
        //public void ReturnObjectWithTheSelectedId_WhenCalledWithValidAndExistingId()
        //{
        //    // Arrange
        //    // In the ClassInitialize method
        //    var selectedId = 2;

        //    // Act
        //    var actualService = new CategoryServiceCrudOperatons(dbContext);            
        //    var actualCategory = actualService.SelectById(selectedId);

        //    // Assert
        //    Assert.AreEqual(selectedId, actualCategory.Id);
        //}

        //[TestMethod]
        //public void ReturnObjectWithAllTheProperties_WhenCalledWithValidAndExistingId()
        //{
        //    // Arrange
        //    var selectedId = 2;

        //    // Act
        //    var actualService = new CategoryServiceCrudOperatons(dbContext);
        //    var actualCategory = actualService.SelectById(selectedId);

        //    // Assert
        //    Assert.AreEqual(testData[selectedId - 1].Id, actualCategory.Id);
        //    Assert.AreEqual(testData[selectedId - 1].Name, actualCategory.Name);

        //}

        [ClassCleanup]
        public static void ClasssCleanup()
        {
            foreach (Category category in testData)
            {
                dbContext.Categories.Attach(category);
                dbContext.Categories.Remove(category);
            }
            dbContext.SaveChanges();
        }
    }
}
