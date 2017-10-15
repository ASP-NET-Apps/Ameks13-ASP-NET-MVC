using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class ProductModelMapper : IGenericModelMapper<Product, ProductCompleteViewModel>
    {
        public ProductModelMapper()
        {
        }

        public ProductCompleteViewModel Model2ViewModel(Product model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            // TODO use no parameter constructor and map properties here
            var viewModelToReturn = new ProductCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Product ViewModel2Model(ProductCompleteViewModel viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

            var modelToReturn = new Product();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;
            modelToReturn.Description = viewModel.Description;

            return modelToReturn;
        }
    }
}