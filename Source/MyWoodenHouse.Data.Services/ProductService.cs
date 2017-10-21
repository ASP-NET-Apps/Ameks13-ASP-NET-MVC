using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services
{
    public class ProductService : BaseGenericService<Product>//, IDataService
    {
        private readonly IEfCrudOperatons<Product> productBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public ProductService(IEfCrudOperatons<Product> productBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
            :  base(productBaseOperatonsProvider, dbContextSaveChanges)
        {
            if (productBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Product> and EfDbContextSaveChanges", "ProductService");
                throw new ArgumentNullException(errorMessage);
            }

            if (productBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Product>", "ProductService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "ProductService");
                throw new ArgumentNullException(errorMessage);
            }

            this.productBaseOperatonsProvider = productBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }

        public IEnumerable<Product> GetAllSortedById()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Product> productsToReturn = this.GetAll().OrderBy(x => x.Id);

            return productsToReturn;
        }

        public IEnumerable<Product> GetAllSortedByName()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Product> productsToReturn = this.GetAll().OrderBy(x => x.Name);

            return productsToReturn;
        }
    }
}
