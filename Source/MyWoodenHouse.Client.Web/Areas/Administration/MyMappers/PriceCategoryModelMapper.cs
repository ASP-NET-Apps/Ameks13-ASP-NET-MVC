using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.PriceCategories;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class PriceCategoryMapper : IGenericModelMapper<PriceCategory, PriceCategoryCompleteViewModel>
    {
        public PriceCategoryMapper()
        {
        }

        public PriceCategoryCompleteViewModel Model2ViewModel(PriceCategory model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            // TODO use no parameter constructor and map properties here
            var viewModelToReturn = new PriceCategoryCompleteViewModel(model);

            return viewModelToReturn;
        }

        public PriceCategory ViewModel2Model(PriceCategoryCompleteViewModel viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

            var modelToReturn = new PriceCategory();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;

            return modelToReturn;
        }
    }
}