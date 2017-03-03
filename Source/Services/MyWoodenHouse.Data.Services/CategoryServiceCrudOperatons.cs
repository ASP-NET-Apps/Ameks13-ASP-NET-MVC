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
        private readonly IDbSet<Category> categoryDbSet;

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
                throw new ArgumentException(errorMessage);
            }
        }

        protected IMyWoodenHouseDbContext Context { get; set; }

        protected IDbSet<Category> DbSet { get; set; }

        public Category SelectById(int id)
        {
            return this.DbSet.Find(id);
        }

        public IEnumerable<Category> Select()
        {
            IEnumerable<Category> categoriesToReturn = this.categoryDbSet.Select(c => c);

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
                categoriesToReturn = this.categoryDbSet.Where(filterExpression).Select(c => c);
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
                this.DbSet.Add(category);
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
                this.DbSet.Attach(category);
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
                this.DbSet.Attach(category);
                this.DbSet.Remove(category);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            Category category = this.SelectById(id);

            if (category == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.NoEntryFoundWithTheProvidedId, id);
                throw new ArgumentException(errorMessage);
            }

            this.Delete(category);
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
        //        this.DbSet.Attach(category);
        //    }

        //    return entryToReturn;
        //}
    }
}
