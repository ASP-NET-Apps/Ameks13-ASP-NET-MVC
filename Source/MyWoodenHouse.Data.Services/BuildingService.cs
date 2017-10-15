using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Provider.Operations.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services
{
    public class BuildingService : IBaseGenericService<Building>//, IDataService
    {
        private readonly IBuildingCrudOperations buildingBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public BuildingService(IBuildingCrudOperations buildingBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            if (buildingBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Building> and EfDbContextSaveChanges", "BuildingService");
                throw new ArgumentNullException(errorMessage);
            }

            if (buildingBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Building>", "BuildingService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "BuildingService");
                throw new ArgumentNullException(errorMessage);
            }

            //this.buildingBaseOperatonsProvider = NinjectWebCommon.Kernel.Get<IBaseGenericService<Building>>();

            this.buildingBaseOperatonsProvider = buildingBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }
               
        public IEnumerable<Building> GetAll()
        {
            var buildingsToReturn = this.buildingBaseOperatonsProvider.SelectAll();

            if (buildingsToReturn == null)
            {
                string errorMessage = nameof(buildingsToReturn);
                throw new ArgumentNullException(errorMessage);
            }

            return buildingsToReturn;
        }

        public Building GetById(int? id)
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

            Building buildingToReturn = this.buildingBaseOperatonsProvider.SelectById(id);
            if (buildingToReturn == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Building", id);
                throw new ArgumentNullException(errorMessage);
            }
            
            return buildingToReturn;
        }

        public int Insert(Building entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            int insertedEntityId = this.buildingBaseOperatonsProvider.Insert(entity);
            this.dbContextSaveChanges.SaveChanges();

            return insertedEntityId;
        }

        public Building Update(Building entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }
            
            this.buildingBaseOperatonsProvider.Update(entity);
            this.dbContextSaveChanges.SaveChanges();

            Building entityUpdated = this.buildingBaseOperatonsProvider.SelectById(entity.Id);

            return entityUpdated;
        }

        public void Delete(Building entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.buildingBaseOperatonsProvider.Delete(entity);
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

            this.buildingBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }
    }
}
