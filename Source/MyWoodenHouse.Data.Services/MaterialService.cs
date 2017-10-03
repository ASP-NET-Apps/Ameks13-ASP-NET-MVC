using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Services
{
    public class MaterialService : IBaseGenericService<Material>
    {
        private readonly IEfCrudOperatons<Material> materialBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public MaterialService(IEfCrudOperatons<Material> materialBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
        {
            if (materialBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Material> and EfDbContextSaveChanges", "MaterialService");
                throw new ArgumentNullException(errorMessage);
            }

            if (materialBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Material>", "MaterialService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "MaterialService");
                throw new ArgumentNullException(errorMessage);
            }

            this.materialBaseOperatonsProvider = materialBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }

        public IEnumerable<Material> GetAll()
        {
            var materialsToReturn = this.materialBaseOperatonsProvider.All.ToList();

            if (materialsToReturn == null)
            {
                string errorMessage = nameof(materialsToReturn);
                throw new ArgumentNullException(errorMessage);
            }

            return materialsToReturn;
        }

        public Material GetById(int? id)
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

            Material materialToReturn = this.materialBaseOperatonsProvider.SelectById(id);
            if (materialToReturn == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Material", id);
                throw new ArgumentNullException(errorMessage);
            }
            
            return materialToReturn;
        }

        public int Insert(Material entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            int insertedEntityId = this.materialBaseOperatonsProvider.Insert(entity);
            this.dbContextSaveChanges.SaveChanges();

            return insertedEntityId;
        }

        public Material Update(Material entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }
            
            this.materialBaseOperatonsProvider.Update(entity);
            this.dbContextSaveChanges.SaveChanges();

            Material entityUpdated = this.materialBaseOperatonsProvider.SelectById(entity.Id);

            return entityUpdated;
        }

        public void Delete(Material entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.materialBaseOperatonsProvider.Delete(entity);
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

            this.materialBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }

    }
}
