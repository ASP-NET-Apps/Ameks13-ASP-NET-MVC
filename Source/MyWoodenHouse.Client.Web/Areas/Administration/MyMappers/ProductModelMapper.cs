using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class ProductModelMapper : IGenericModelMapper<Product, ProductCompleteViewModel>
    {
        public ProductCompleteViewModel Model2ViewModel(Product model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new ProductCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Product ViewModel2Model(ProductCompleteViewModel viewModel)
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