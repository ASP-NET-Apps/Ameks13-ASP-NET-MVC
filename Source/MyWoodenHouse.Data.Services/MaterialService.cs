using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services
{
    public class MaterialService : BaseGenericService<Material>, IMaterialService //, IDataService
    {
        private readonly IEfCrudOperatons<Material> materialBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public MaterialService(IEfCrudOperatons<Material> materialBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges) 
            : base(materialBaseOperatonsProvider, dbContextSaveChanges)
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

        public IEnumerable<Material> GetAllSortedById()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Material> materialsToReturn = this.GetAll().OrderBy(x => x.Id);

            return materialsToReturn;
        }

        public IEnumerable<Material> GetAllSortedByName()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Material> materialsToReturn = this.GetAll().OrderBy(x => x.Name);

            return materialsToReturn;
        }
    }
}
