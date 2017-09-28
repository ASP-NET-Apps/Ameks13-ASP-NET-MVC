﻿using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.PriceCategories;
using MyWoodenHouse.Ef.Models;
using System;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class PriceCategoryModelMapper : IGenericModelMapper<PriceCategory, PriceCategoryCompleteViewModel>
    {
        public PriceCategoryCompleteViewModel Model2ViewModel(PriceCategory model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new PriceCategoryCompleteViewModel(model);

            return viewModelToReturn;
        }

        public PriceCategory ViewModel2Model(PriceCategoryCompleteViewModel viewModel)
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