using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
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
            if (categoryBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Category> and EfDbContextSaveChanges", "CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            if (categoryBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Category>", "CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            this.categoryBaseOperatonsProvider = categoryBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }
        
        public IEnumerable<Category> GetAllCategories()
        {
            IList<Category> categoriesToReturn = null;
            IEnumerable<Category> categories  = this.categoryBaseOperatonsProvider.All.ToList();

            if (categories == null)
            {
                string errorMessage = nameof(categories);
                throw new ArgumentNullException(errorMessage);
            }

            if (categories.Count() > 0)
            {
                categoriesToReturn = new List<Category>();

                foreach(var category in categories)
                {
                    //var c = new Category(category);
                    categoriesToReturn.Add(category);
                }
            }

            return categoriesToReturn;
        }

        public IEnumerable<Category> GetAllCategoriesSortedById()
        {
            IEnumerable<Category> categoriesToReturn = this.GetAllCategories().OrderBy(c => c.Id);

            return categoriesToReturn;
        }

        public IEnumerable<Category> GetAllCategoriesSortedByName()
        {
            IEnumerable<Category> categoriesToReturn = this.GetAllCategories().OrderBy(c => c.Name);

            return categoriesToReturn;
        }

        public Category GetCategoryById(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithNotNullableParameter, "null");
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            Category categoryToReturn = this.categoryBaseOperatonsProvider.SelectById(id);

            if (categoryToReturn == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Category", id);
                throw new ArgumentNullException(errorMessage);
            }

            return categoryToReturn;
        }

        public int InsertCategory(Category category)
        {
            if (category == null)
            {
                string errorMessage = nameof(category);
                throw new ArgumentNullException(errorMessage);
            }

            // TODO create MyDbModelsMapper.Category2Category
            Category categoryToInsert = new Category();
            categoryToInsert.Name = category.Name;

            int insertedCategoryId = this.categoryBaseOperatonsProvider.Insert(categoryToInsert);
            this.dbContextSaveChanges.SaveChanges();

            return insertedCategoryId;
        }

        public Category UpdateCategory(Category category)
        {
            if (category == null)
            {
                string errorMessage = nameof(category);
                throw new ArgumentNullException(errorMessage);
            }

            this.categoryBaseOperatonsProvider.Update(category);
            this.dbContextSaveChanges.SaveChanges();

            return category;
        }

        public void DeleteCategoryById(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, "null");
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            this.categoryBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }
    }
}
