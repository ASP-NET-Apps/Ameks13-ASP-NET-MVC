using MyWoodenHouse.Data.Models.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Services
{
    public class EfDbContextSaveChanges : IEfDbContextSaveChanges
    {
        private readonly IMyWoodenHouseDbContext context;

        public EfDbContextSaveChanges(IMyWoodenHouseDbContext context)
        {
            if (context == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "Data CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            this.context = context;
        }

        public int SaveChanges()
        {
            int saveChangesResult =  this.context.SaveChanges();

            return saveChangesResult;
        }
    }
}
