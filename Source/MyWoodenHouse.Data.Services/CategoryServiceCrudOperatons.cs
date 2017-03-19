using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Models.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Services
{
    public class CategoryServiceCrudOperatons : ICategoryServiceCrudOperatons
    {
        private readonly IMyWoodenHouseDbContext context;
        private readonly DbSet<Category> categoryDbSet;

        public CategoryServiceCrudOperatons(IMyWoodenHouseDbContext context)
        {           
            if (context == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "Data CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            this.context = context;
            this.categoryDbSet = this.context.Set<Category>();

            if (this.categoryDbSet == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.DbContextDoesNotContainDbSet, typeof(Category).Name);
                throw new ArgumentNullException(errorMessage);
            }
        }

        public IMyWoodenHouseDbContext Context
        {
            get
            {
                return this.context;
            }
        }
        
        public DbSet<Category> CategoryDbSet
        {
            get
            {
                return this.categoryDbSet;
            }
        }

        public Category SelectById(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithNotNullableParameter);
                throw new ArgumentException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            return this.CategoryDbSet.Find(id);
        }

        public IEnumerable<Category> Select()
        {
            IEnumerable<Category> categoriesToReturn = this.CategoryDbSet.Select(c => c);

            return categoriesToReturn;
        }

        public IEnumerable<Category> Select(Expression<Func<Category, bool>> filterExpression)
        {
            IEnumerable<Category> categoriesToReturn = null;

            if (filterExpression == null)
            {
                categoriesToReturn = this.Select();
            }
            else
            {
                categoriesToReturn = this.CategoryDbSet.Where(filterExpression).Select(c => c);
            }

            return categoriesToReturn;
        }

        public void Insert(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            DbEntityEntry entry = this.Context.Entry(category);
            if(entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                category.Id = this.GetMaxId() + 1;
                this.CategoryDbSet.Add(category);
            }
        }

        public void Update(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            DbEntityEntry entry = this.Context.Entry(category);
            if(entry.State != EntityState.Detached)
            {
                this.CategoryDbSet.Attach(category);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            DbEntityEntry entry = this.Context.Entry(category);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.CategoryDbSet.Attach(category);
                this.CategoryDbSet.Remove(category);
            }
        }

        public void Delete(int? id)
        {
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            Category category = this.SelectById(id);

            if (category == null)
            {
                string errorMessage = string.Format(Consts.GeneralData.ErrorMessage.NoEntryFoundWithTheProvidedId, id);
                throw new ArgumentException(errorMessage);
            }

            this.Delete(category);
        }

        public int GetMaxId()
        {
            int maxId = -1;

            try
            {
                maxId = this.categoryDbSet.Max(c => c.Id);
            }
            catch (InvalidOperationException)
            {
                // When Categories table is empty, EntityFramework returns InvalidOperationException
                // We assign Zero to the current Id and the first inserted item will be with
                // Id = 0 + 1; 
                maxId = 0;
            }
            catch
            {
                throw new ArgumentException();
            }

            bool isValidId = (maxId >= 0);
            if (!isValidId)
            {
                // TODO extract constant
                string errorMessage = string.Format("Category MaxId is not valid id = {0}", maxId);
                throw new ArgumentException();
            }        

            return maxId;
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        //private DbEntityEntry<Category> AttachIfDeteched(Category category)
        //{
        //    DbEntityEntry<Category> entryToReturn = this.Context.Entry(category);
        //    if (entryToReturn.State == EntityState.Detached)
        //    {
        //        this.CategoryDbSet.Attach(category);
        //    }

        //    return entryToReturn;
        //}
    }
}
