using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.PriceCategories;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class PriceCategoryMapper : IGenericModelMapper<PriceCategory, PriceCategoryCompleteVm>
    {
        public PriceCategoryMapper()
        {
        }

        public PriceCategoryCompleteVm Model2ViewModel(PriceCategory model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            var viewModelToReturn = new PriceCategoryCompleteVm();
            viewModelToReturn.Id = model.Id;
            viewModelToReturn.Name = model.Name;

            return viewModelToReturn;
        }

        public PriceCategory ViewModel2Model(PriceCategoryCompleteVm viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

            var modelToReturn = new PriceCategory();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;

            return modelToReturn;
        }
    }
}