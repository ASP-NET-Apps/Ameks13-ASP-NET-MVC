using System;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Material;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class MaterialModelMapper
    {
        public MaterialCompleteViewModel MaterialModel2MaterialCompleteViewModel(IMaterial model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new MaterialCompleteViewModel(model);

            return modelToReturn;
        }

        public Material MaterialCompleteViewModel2MaterialModel(MaterialCompleteViewModel model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var materialToReturn = new Material();
            materialToReturn.Id = model.Id;
            materialToReturn.Name = model.Name;
            materialToReturn.Description = model.Description;

            return materialToReturn;
        }
    }
}