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
    public class PictureService : IBaseGenericService<Picture>, IDataService
    {
        private readonly IEfCrudOperatons<Picture> pictureBaseOperatonsProvider;
        private readonly IEfDbContextSaveChanges dbContextSaveChanges;

        public PictureService(IEfCrudOperatons<Picture> pictureBaseOperatonsProvider, IEfDbContextSaveChanges dbContextSaveChanges)
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

       
        public IEnumerable<Picture> GetAll()
        {
            var picturesToReturn = this.pictureBaseOperatonsProvider.SelectAll();

            if (picturesToReturn == null)
            {
                string errorMessage = nameof(picturesToReturn);
                throw new ArgumentNullException(errorMessage);
            }

            return picturesToReturn;
        }

        public Picture GetById(int? id)
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

            Picture pictureToReturn = this.pictureBaseOperatonsProvider.SelectById(id);
            if (pictureToReturn == null)
            {
                string errorMessage = string.Format(Consts.SelectData.ErrorMessage.NoItemFoundByTheGivenId, "Picture", id);
                throw new ArgumentNullException(errorMessage);
            }
            
            return pictureToReturn;
        }

        public int Insert(Picture entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            int insertedEntityId = this.pictureBaseOperatonsProvider.Insert(entity);
            this.dbContextSaveChanges.SaveChanges();

            return insertedEntityId;
        }

        public Picture Update(Picture entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }
            
            this.pictureBaseOperatonsProvider.Update(entity);
            this.dbContextSaveChanges.SaveChanges();

            Picture entityUpdated = this.pictureBaseOperatonsProvider.SelectById(entity.Id);

            return entityUpdated;
        }

        public void Delete(Picture entity)
        {
            if (entity == null)
            {
                string errorMessage = nameof(entity);
                throw new ArgumentNullException(errorMessage);
            }

            this.pictureBaseOperatonsProvider.Delete(entity);
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

            this.pictureBaseOperatonsProvider.Delete(id);
            this.dbContextSaveChanges.SaveChanges();
        }

        
    }
}
