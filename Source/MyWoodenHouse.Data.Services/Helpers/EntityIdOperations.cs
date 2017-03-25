using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts;
using System;
using System.Data.Entity;
using System.Linq;

namespace MyWoodenHouse.Data.Services.Helpers
{
    public class EntityIdOperations<T> where T : class, IHasIntId
    {
        private readonly IDbSet<T> dbSet;

        public EntityIdOperations(IDbSet<T> dbSet)
        {
            if (dbSet == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "Data CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            this.dbSet = dbSet;
        }

        private int GetMaxId()
        {
            int maxId = -1;

            try
            {
                maxId = this.dbSet.Max(c => c.Id);
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
