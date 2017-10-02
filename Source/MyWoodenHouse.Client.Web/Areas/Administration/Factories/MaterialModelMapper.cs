using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class MaterialModelMapper : IGenericModelMapper<IMaterial, IMaterialComleteViewModel>
    {
        public IMaterialComleteViewModel Model2ViewModel(IMaterial model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new MaterialCompleteViewModel(model);

            return viewModelToReturn;
        }

        public IMaterial ViewModel2Model(IMaterialComleteViewModel viewModel)
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