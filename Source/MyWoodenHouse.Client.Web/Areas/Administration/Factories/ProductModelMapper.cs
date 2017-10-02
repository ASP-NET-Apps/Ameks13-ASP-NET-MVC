using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Contracts.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class ProductModelMapper : IGenericModelMapper<IProduct, IProductCompleteViewModel>
    {
        public IProductCompleteViewModel Model2ViewModel(IProduct model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new ProductCompleteViewModel(model);

            return viewModelToReturn;
        }

        public IProduct ViewModel2Model(IProductCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new Product();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;
            modelToReturn.Description = viewModel.Description;

            return modelToReturn;
        }
    }
}