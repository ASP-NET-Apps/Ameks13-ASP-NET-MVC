using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.PureModels;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Pure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfCrudOperatons<Category> categoryBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public CategoryService(IEfCrudOperatons<Category> categoryBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            if (categoryBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "categoryBaseOperatonsProvider", "Data CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "dbContextSaveChanges", "Data CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            this.categoryBaseOperatonsProvider = categoryBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }
        
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            IList<CategoryModel> categoriesToReturn = null;
            IEnumerable<Category> categories  = this.categoryBaseOperatonsProvider.All.ToList();

            if (categories == null)
            {
                string errorMessage = nameof(categories);
                throw new ArgumentNullException(errorMessage);
            }

            if (categories.Count() > 0)
            {
                categoriesToReturn = new List<CategoryModel>();

                foreach(var category in categories)
                {
                    var c = new CategoryModel(category);
                    categoriesToReturn.Add(c);
                }
            }

            return categoriesToReturn;
        }

        public IEnumerable<CategoryModel> GetAllCategoriesSortedById()
        {
            IEnumerable<CategoryModel> categoriesToReturn = this.GetAllCategories().OrderBy(c => c.Id);

            return categoriesToReturn;
        }

        public IEnumerable<CategoryModel> GetAllCategoriesSortedByName()
        {
            IEnumerable<CategoryModel> categoriesToReturn = this.GetAllCategories().OrderBy(c => c.Name);

            return categoriesToReturn;
        }

        public ICategoryModel InsertCategory(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                string errorMessage = nameof(categoryModel);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper()
            Category categoryToInsert = new Category();
            categoryToInsert.Name = categoryModel.Name;

            this.categoryBaseOperatonsProvider.Insert(categoryToInsert);
            this.dbContextSaveChanges.SaveChanges();

            return categoryModel;
        }

    }
}
