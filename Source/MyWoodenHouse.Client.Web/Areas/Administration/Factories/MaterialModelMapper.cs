using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class MaterialModelMapper : IGenericModelMapper<Material, MaterialCompleteViewModel>
    {
        public MaterialCompleteViewModel Model2ViewModel(Material model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new MaterialCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Material ViewModel2Model(MaterialCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new Material();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;
            modelToReturn.Description = viewModel.Description;

            return modelToReturn;
        }
        
    }
}