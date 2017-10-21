using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    //public class CategoryModelMapper : IGenericModelMapper<Category, CategoryCompleteVm>
    public class CategoryModelMapper : ICategoryModelMapper
    {
        public CategoryModelMapper()
        {
        }

        public CategoryCompleteVm Model2ViewModel(Category model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();
            
            var modelToReturn = new CategoryCompleteVm();
            modelToReturn.Id = model.Id;
            modelToReturn.Name = model.Name;

            return modelToReturn;
        }
       
        public Category ViewModel2Model(CategoryCompleteVm viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

            var modelToReturn = new Category();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;

            return modelToReturn;
        }
    }
}