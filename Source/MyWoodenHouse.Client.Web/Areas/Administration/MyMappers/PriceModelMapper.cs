using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Prices;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class PriceModelMapper : IGenericModelMapper<Price, PriceCompleteViewModel>
    {
        public PriceModelMapper()
        {
        }

        public PriceCompleteViewModel Model2ViewModel(Price model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            // TODO use no parameter constructor and map properties here
            var viewModelToReturn = new PriceCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Price ViewModel2Model(PriceCompleteViewModel viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

            var modelToReturn = new Price();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Value = viewModel.Value;
            modelToReturn.Currency = viewModel.Currency;
            modelToReturn.PerSquareMeter = viewModel.PerSquareMeter;
            modelToReturn.PriceCategoryId = viewModel.PriceCategoryId;

            return modelToReturn;
        }
    }
}