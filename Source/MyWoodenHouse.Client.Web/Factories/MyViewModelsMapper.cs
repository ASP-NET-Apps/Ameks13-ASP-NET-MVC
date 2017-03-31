using MyWoodenHouse.Client.Web.Factories.Contracts;
using MyWoodenHouse.Client.Web.ViewModels.Categories;
using MyWoodenHouse.Pure.Models;
using System;

namespace MyWoodenHouse.Client.Web.Factories
{
    public class MyViewModelsMapper : IMyViewModelsMapper
    {
        public CategoryMainViewModel CategoryModel2CategoryViewModel(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategoryViewModel = new CategoryMainViewModel(categoryModel);

            return newCategoryViewModel;
        }

        public CategoryModel CategoryViewModel2CategoryModel(CategoryMainViewModel categoryViewModel)
        {
            if (categoryViewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategoryModel = new CategoryModel();
            newCategoryModel.Id = categoryViewModel.Id;
            newCategoryModel.Name = categoryViewModel.Name;

            return newCategoryModel;
        }
    }
}