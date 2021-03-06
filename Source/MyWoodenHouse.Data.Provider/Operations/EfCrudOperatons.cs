﻿using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Enums;
using MyWoodenHouse.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MyWoodenHouse.Data.Provider.Operations
{
    public class EfCrudOperatons<T> : IEfCrudOperatons<T> where T : class, IHasIntId, IDeletable, IAuditable
    {
        private readonly MyWoodenHouseDbContext context;
        private readonly DbSet<T> dbSet;

        public EfCrudOperatons(MyWoodenHouseDbContext context)
        {
            // TODO use Guard package
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

        public MyWoodenHouseDbContext Context
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
                return this.DbSet.Where(x => !x.IsDeleted);
            }
        }

        public IQueryable<T> AllAndDeleted
        {
            get
            {
                return this.DbSet;
            }
        }

        public IEnumerable<T> SelectAll()
        {
            IEnumerable<T> itemsToReturn = this.All.Select(y => y);

            return itemsToReturn;
        }

        public IEnumerable<T> SelectAll(Expression<Func<T, bool>> filterExpression)
        {
            IEnumerable<T> itemsToReturn = null;

            if (filterExpression == null)
            {
                itemsToReturn = this.SelectAll();
            }
            else
            {
                itemsToReturn = this.All.Where(filterExpression).Select(c => c);
            }

            return itemsToReturn;
        }

        public IEnumerable<T> SelectAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, SortOrder? sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T2> SelectAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, SortOrder? sortOrder, Expression<Func<T, T2>> selectExpression)
        {
            throw new NotImplementedException();
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

        public virtual int Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = this.GetMaxId() + 1;
            entity.CreatedOn = DateTime.Now;

            bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;
            if (!isStateDetached)
            {
                this.Context.SetEntityState(entity, EntityState.Added);
            }
            else
            {
                this.DbSet.Add(entity);
            }

            return entity.Id;
        }

        public virtual int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.ModifiedOn = DateTime.Now;

            bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;
            if (isStateDetached)
            {
                this.DbSet.Attach(entity);
            }

            this.Context.SetEntityState(entity, EntityState.Modified);

            return entity.Id;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            entity.ModifiedOn = entity.DeletedOn;

            bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;
            if (isStateDetached)
            {
                this.DbSet.Attach(entity);
            }

            this.Context.SetEntityState(entity, EntityState.Modified);
        }

        public void Delete(int? id, string username)
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

            entity.ModifiedBy = username;

            this.Delete(entity);
        }

        public void DeletePermanent(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool isStateDetached = this.Context.GetEntityState(entity) == EntityState.Detached;
            if (!isStateDetached)
            {
                this.Context.SetEntityState(entity, EntityState.Deleted);
            }
            else
            {
                this.DbSet.Remove(entity);
            }
        }

        protected int GetMaxId()
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

        protected DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }

        protected void AttachEntityIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }
        }

        private T CopyStateFrom(T entity)
        {
            var dbEntity = this.DbSet.Create();
            var type = typeof(T);
            var properties = type.GetProperties();

            foreach (var srcProp in properties)
            {
                if (!srcProp.CanRead)
                {
                    continue;
                }

                var targetProperty = type.GetProperty(srcProp.Name);
                if (targetProperty == null)
                {
                    continue;
                }

                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }

                if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                {
                    continue;
                }

                if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                {
                    continue;
                }

                targetProperty.SetValue(dbEntity, srcProp.GetValue(entity, null), null);
            }

            return dbEntity;
        }
        
    }
}
