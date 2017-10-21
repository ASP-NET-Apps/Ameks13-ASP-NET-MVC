using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
using MyWoodenHouse.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services
{
    //public class EfCrudOperatons<T> : IEfCrudOperatons<T> where T : class, IHasIntId, IDeletable, IAuditable

    public abstract class BaseGenericService<T> : IBaseGenericService<T> where T: class, IHasIntId
    {
        private readonly IEfCrudOperatons<T> baseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public BaseGenericService(IEfCrudOperatons<T> baseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            this.baseOperatonsProvider = baseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }
        
        public IEnumerable<T> GetAll()
        {
            var entitiesToReturn = this.baseOperatonsProvider.All.ToList();

            if (entitiesToReturn == null)
            {
                string errorMessage = nameof(entitiesToReturn);
                throw new ArgumentNullException(errorMessage);
            }

            return entitiesToReturn;
        }

        public T GetById(int? id)
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

            T entityToReturn = this.baseOperatonsProvider.SelectById(id);
            if (entityToReturn == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "T", id);
                throw new ArgumentNullException(errorMessage);
            }

            return entityToReturn;
        }

        public int Insert(T entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            int insertedEntityId = this.baseOperatonsProvider.Insert(entity);
            this.dbContextSaveChanges.SaveChanges();

            return insertedEntityId;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.baseOperatonsProvider.Update(entity);
            this.dbContextSaveChanges.SaveChanges();

            T entityUpdated = this.baseOperatonsProvider.SelectById(entity.Id);

            return entityUpdated;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.baseOperatonsProvider.Delete(entity);
            this.dbContextSaveChanges.SaveChanges();
        }

        public void Delete(int? id, string username)
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

            this.baseOperatonsProvider.Delete(id, username);
            this.dbContextSaveChanges.SaveChanges();
        }
    }
}
