using System;
using MyWoodenHouse.Pure.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class CategoryModelMapper : IGenericModelMapper<CategoryModel, CategoryCompleteViewModel>
    {
        public CategoryCompleteViewModel Model2ViewModel(CategoryModel model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new CategoryCompleteViewModel(model);

            return modelToReturn;
        }

        public CategoryModel ViewModel2Model(CategoryCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new CategoryModel();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;

            return modelToReturn;
        }
    }
}