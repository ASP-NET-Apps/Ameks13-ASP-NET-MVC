using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class MaterialModelMapper : IGenericModelMapper<Material, MaterialCompleteVm>
    {
        public MaterialModelMapper()
        {
        }

        public MaterialCompleteVm Model2ViewModel(Material model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            var viewModelToReturn = new MaterialCompleteVm();
            viewModelToReturn.Id = model.Id;
            viewModelToReturn.Name = model.Name;
            viewModelToReturn.Description = model.Description;

            return viewModelToReturn;
        }

        public Material ViewModel2Model(MaterialCompleteVm viewModel)
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