using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services
{
    public class CategoryService : IBaseGenericService<Category>//, IDataService
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
        
        public IEnumerable<Category> GetAll()
        {
            var categoriesToReturn = this.categoryBaseOperatonsProvider.All.ToList();

            if (categoriesToReturn == null)
            {
                string errorMessage = nameof(categoriesToReturn);
                throw new ArgumentNullException(errorMessage);
            }

            return categoriesToReturn;
        }

        public IEnumerable<Category> GetAllSortedById()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Category> categoriesToReturn = this.GetAll().OrderBy(c => c.Id);

            return categoriesToReturn;
        }

        public IEnumerable<Category> GetAllSortedByName()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Category> categoriesToReturn = this.GetAll().OrderBy(c => c.Name);

            return categoriesToReturn;
        }

        public Category GetById(int? id)
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

        public int Insert(Category entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            int insertedEntityId = this.categoryBaseOperatonsProvider.Insert(entity);
            this.dbContextSaveChanges.SaveChanges();

            return insertedEntityId;
        }

        public Category Update(Category entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.categoryBaseOperatonsProvider.Update(entity);
            this.dbContextSaveChanges.SaveChanges();

            Category entityUpdated = this.categoryBaseOperatonsProvider.SelectById(entity.Id);

            return entityUpdated;
        }

        public void Delete(Category entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.categoryBaseOperatonsProvider.Delete(entity);
            this.dbContextSaveChanges.SaveChanges();
        }

        public void Delete(int? id)
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
