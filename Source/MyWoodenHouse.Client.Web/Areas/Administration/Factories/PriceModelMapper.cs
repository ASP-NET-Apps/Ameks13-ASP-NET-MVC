using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Prices;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Contracts.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class PriceModelMapper : IGenericModelMapper<IPrice, IPriceCompleteViewModel>
    {
        public IPriceCompleteViewModel Model2ViewModel(IPrice model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new PriceCompleteViewModel(model);

            return viewModelToReturn;
        }

        public IPrice ViewModel2Model(IPriceCompleteViewModel viewModel)
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