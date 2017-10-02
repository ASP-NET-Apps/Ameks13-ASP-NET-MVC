using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.PriceCategories;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Ef.Models;
using System;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class PriceCategoryModelMapper : IGenericModelMapper<IPriceCategory, IPriceCategoryCompleteViewModel>
    {
        public IPriceCategoryCompleteViewModel Model2ViewModel(IPriceCategory model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new PriceCategoryCompleteViewModel(model);

            return viewModelToReturn;
        }

        public IPriceCategory ViewModel2Model(IPriceCategoryCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new PriceCategory();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;

            return modelToReturn;
        }
    }
}