using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Models.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Services
{
    public class CategoryService
    {
        private readonly IMyWoodenHouseDbContext context;
        private readonly IDbSet<Category> categoryDbSet;

        public CategoryService(IMyWoodenHouseDbContext context)
        {           
            if (context == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "MyWoodenHouseDbContext", "Data CategoryService");
                throw new ArgumentNullException(errorMessage);
            }

            this.context = context;
            this.categoryDbSet = this.context.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categoriesToReturn = this.categoryDbSet.Select(c => c);

            return categoriesToReturn;
        }
    }
}
