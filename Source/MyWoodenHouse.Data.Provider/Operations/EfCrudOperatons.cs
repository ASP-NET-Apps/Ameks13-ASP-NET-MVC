using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts;
using MyWoodenHouse.Data.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MyWoodenHouse.Data.Provider.Operations
{
    public class EfCrudOperatons<T> : IEfCrudOperatons<T> where T : class, IHasIntId
    {
        private readonly IMyWoodenHouseDbContext context;
        private readonly DbSet<T> dbSet;

        public EfCrudOperatons(IMyWoodenHouseDbContext context)
        {
            if (context == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "Data CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            this.context = context;
            this.dbSet = this.context.Set<T>();

            if (this.dbSet == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.DbContextDoesNotContainDbSet, typeof(T).Name);
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

        public DbSet<T> DbSet
        {
            get
            {
                return this.dbSet;
            }
        }

        public IQueryable<T> All
        {
            get
            {
                return this.dbSet;
            }
        }

        public T SelectById(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithNotNullableParameter);
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.SelectByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            return this.DbSet.Find(id);
        }

        public IEnumerable<T> Select()
        {
            IEnumerable<T> categoriesToReturn = this.DbSet.Select(c => c);

            return categoriesToReturn;
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> filterExpression)
        {
            IEnumerable<T> itemsToReturn = null;

            if (filterExpression == null)
            {
                itemsToReturn = this.Select();
            }
            else
            {
                itemsToReturn = this.DbSet.Where(filterExpression).Select(c => c);
            }

            return itemsToReturn;
        }

        public int Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;
            if (!isStateDetached)
            {
                this.Context.SetEntityState(entity, EntityState.Added);
            }
            else
            {
                entity.Id = this.GetMaxId() + 1;
                this.DbSet.Add(entity);
            }

            return entity.Id;
        }

        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;

            if (!isStateDetached)
            {
                this.DbSet.Attach(entity);
            }

            this.Context.SetEntityState(entity, EntityState.Modified);

            return entity.Id;
        }

        public void Delete(T category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            bool isStateDeleted = this.Context.GetEntityState(category) == EntityState.Deleted;
            if (!isStateDeleted)
            {
                this.Context.SetEntityState(category, EntityState.Deleted);
            }
            else
            {
                this.DbSet.Attach(category);
                this.DbSet.Remove(category);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithNotNullableParameter);
                throw new ArgumentNullException(errorMessage);
            }
            if (id <= 0)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.DeleteByIdIsPossibleOnlyWithPositiveParameter, id);
                throw new ArgumentException(errorMessage);
            }

            T entity = this.SelectById(id);

            if (entity == null)
            {
                string errorMessage = string.Format(Consts.DeleteData.ErrorMessage.NoItemDeletedByTheGivenId, id);
                throw new ArgumentNullException(errorMessage);
            }

            this.Delete(entity);
        }

        private int GetMaxId()
        {
            int maxId = -1;

            try
            {
                maxId = this.DbSet.Max(c => c.Id);
            }
            catch (InvalidOperationException)
            {
                // When table is empty, EntityFramework returns InvalidOperationException
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

        
    }
}
