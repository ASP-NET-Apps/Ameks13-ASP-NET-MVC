using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class PriceModelMapper : IGenericModelMapper<Price, PriceCompleteVm>
    {
        public PriceModelMapper()
        {
        }

        public PriceCompleteVm Model2ViewModel(Price model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            var viewModelToReturn = new PriceCompleteVm();
            viewModelToReturn.Id = model.Id;
            viewModelToReturn.Value = model.Value;
            viewModelToReturn.Currency = model.Currency;
            viewModelToReturn.PerSquareMeter = model.PerSquareMeter;
            viewModelToReturn.PriceCategoryId = model.PriceCategoryId;

            return viewModelToReturn;
        }

        public Price ViewModel2Model(PriceCompleteVm viewModel)
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