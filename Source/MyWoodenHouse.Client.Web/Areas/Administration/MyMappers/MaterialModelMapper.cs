using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class MaterialModelMapper : IGenericModelMapper<Material, MaterialCompleteViewModel>
    {
        public MaterialModelMapper()
        {
        }

        public MaterialCompleteViewModel Model2ViewModel(Material model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            // TODO use no parameter constructor and map properties here
            var viewModelToReturn = new MaterialCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Material ViewModel2Model(MaterialCompleteViewModel viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

            var modelToReturn = new Material();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;
            modelToReturn.Description = viewModel.Description;

            return modelToReturn;
        }
        
    }
}