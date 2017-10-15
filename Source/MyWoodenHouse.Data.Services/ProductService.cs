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
    public class ProductService : IBaseGenericService<Product>, IDataService
    {
        private readonly IEfCrudOperatons<Product> productBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public ProductService(IEfCrudOperatons<Product> productBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
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

       
        public IEnumerable<Product> GetAll()
        {
            var productsToReturn = this.productBaseOperatonsProvider.SelectAll();

            if (productsToReturn == null)
            {
                string errorMessage = nameof(productsToReturn);
                throw new ArgumentNullException(errorMessage);
            }

            return productsToReturn;
        }

        public Product GetById(int? id)
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

            Product productToReturn = this.productBaseOperatonsProvider.SelectById(id);
            if (productToReturn == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Product", id);
                throw new ArgumentNullException(errorMessage);
            }
            
            return productToReturn;
        }

        public int Insert(Product entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            int insertedEntityId = this.productBaseOperatonsProvider.Insert(entity);
            this.dbContextSaveChanges.SaveChanges();

            return insertedEntityId;
        }

        public Product Update(Product entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }
            
            this.productBaseOperatonsProvider.Update(entity);
            this.dbContextSaveChanges.SaveChanges();

            Product entityUpdated = this.productBaseOperatonsProvider.SelectById(entity.Id);

            return entityUpdated;
        }

        public void Delete(Product entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.productBaseOperatonsProvider.Delete(entity);
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

            this.productBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }
    }
}
