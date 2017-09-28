using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Prices;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class PriceModelMapper : IGenericModelMapper<Price, PriceCompleteViewModel>
    {
        public PriceCompleteViewModel Model2ViewModel(Price model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new PriceCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Price ViewModel2Model(PriceCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

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