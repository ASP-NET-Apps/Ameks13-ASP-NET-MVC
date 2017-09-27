using System;
using MyWoodenHouse.Pure.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class CategoryModelMapper : ICategoryModelMapper
    {
        public CategoryCompleteViewModel CategoryModel2CategoryCompleteViewModel(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategoryCompleteVM = new CategoryCompleteViewModel(categoryModel);

            return newCategoryCompleteVM;
        }

        public CategoryModel CategoryCompleteViewModel2CategoryModel(CategoryCompleteViewModel categoryCompleteViewModel)
        {
            if (categoryCompleteViewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategoryModel = new CategoryModel();
            newCategoryModel.Id = categoryCompleteViewModel.Id;
            newCategoryModel.Name = categoryCompleteViewModel.Name;

            return newCategoryModel;
        }
    }
}