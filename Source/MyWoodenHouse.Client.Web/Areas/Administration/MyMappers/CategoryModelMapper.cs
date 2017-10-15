using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class CategoryModelMapper : IGenericModelMapper<Category, CategoryCompleteViewModel>
    {
        public CategoryCompleteViewModel Model2ViewModel(Category model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();
            
            // TODO use no parameter constructor and map properties here
            var modelToReturn = new CategoryCompleteViewModel(model);

            return modelToReturn;
        }
       
        public Category ViewModel2Model(CategoryCompleteViewModel viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

            var modelToReturn = new Category();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;

            return modelToReturn;
        }
    }
}