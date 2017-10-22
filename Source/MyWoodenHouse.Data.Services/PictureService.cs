using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Data.Services.Contracts;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Data.Services
{
    public class PictureService : BaseGenericService<Picture>, IPictureService //, IDataService
    {
        private readonly IEfCrudOperatons<Picture> pictureBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public PictureService(IEfCrudOperatons<Picture> pictureBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
            : base(pictureBaseOperatonsProvider, dbContextSaveChanges)
        {
            if (pictureBaseOperatonsProvider == null && dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Picture> and EfDbContextSaveChanges", "PictureService");
                throw new ArgumentNullException(errorMessage);
            }

            if (pictureBaseOperatonsProvider == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfCrudOperatons<Picture>", "PictureService");
                throw new ArgumentNullException(errorMessage);
            }

            if (dbContextSaveChanges == null)
            {
                string errorMessage = string.Format(Consts.Constuctor.ErrorMessage.AnInstanceOfObjectIsRequiredToConstructClass, "EfDbContextSaveChanges", "PictureService");
                throw new ArgumentNullException(errorMessage);
            }

            this.pictureBaseOperatonsProvider = pictureBaseOperatonsProvider;
            this.dbContextSaveChanges = dbContextSaveChanges;
        }

        public IEnumerable<Picture> GetAllSortedById()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Picture> picturesToReturn = this.GetAll().OrderBy(x => x.Id);

            return picturesToReturn;
        }

        public IEnumerable<Picture> GetAllSortedByName()
        {
            // TODO refactoring to use All IQueriable from the service
            IEnumerable<Picture> picturesToReturn = this.GetAll().OrderBy(x => x.Name);

            return picturesToReturn;
        }
        
    }
}
