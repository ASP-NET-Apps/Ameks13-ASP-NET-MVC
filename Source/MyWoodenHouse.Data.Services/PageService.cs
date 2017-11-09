using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services
{
    public class PageService : BaseGenericService<Page>, IPageService//, IDataService
    {
        private readonly IEfCrudOperatons<Page> productBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public PageService(IEfCrudOperatons<Page> productBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
            :  base(productBaseOperatonsProvider, dbContextSaveChanges)
        {
            if (productBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Page> and EfDbContextSaveChanges", "PageService");
                throw new ArgumentNullException(errorMessage);
            }

            if (productBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Page>", "PageService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "PageService");
                throw new ArgumentNullException(errorMessage);
            }

            this.productBaseOperatonsProvider = productBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }

        public IEnumerable<Page> GetAllSortedById()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Page> productsToReturn = this.GetAll().OrderBy(x => x.Id);

            return productsToReturn;
        }

        public IEnumerable<Page> GetAllSortedByName()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Page> productsToReturn = this.GetAll().OrderBy(x => x.Name);

            return productsToReturn;
        }
    }
}
