using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class ProductModelMapper : IGenericModelMapper<Product, ProductCompleteVm>
    {
        public ProductModelMapper()
        {
        }

        public ProductCompleteVm Model2ViewModel(Product model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            var viewModelToReturn = new ProductCompleteVm();
            viewModelToReturn.Id = model.Id;
            viewModelToReturn.Name = model.Name;
            viewModelToReturn.Description = model.Description;

            return viewModelToReturn;
        }

        public Product ViewModel2Model(ProductCompleteVm viewModel)
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