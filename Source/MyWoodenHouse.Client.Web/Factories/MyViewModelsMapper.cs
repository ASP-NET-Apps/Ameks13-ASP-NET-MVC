using MyWoodenHouse.Client.Web.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.ViewModels.Categories;
using MyWoodenHouse.Models;
using System;

namespace MyWoodenHouse.Client.Web.MyMappers
{
    public class MyViewModelsMapper : IMyViewModelsMapper
    {
        public CategoryMainViewModel Category2CategoryViewModel(Category categoryModel)
        {
            if (categoryModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategoryViewModel = new CategoryMainViewModel(categoryModel);

            return newCategoryViewModel;
        }

        public Category CategoryViewModel2Category(CategoryMainViewModel categoryViewModel)
        {
            if (categoryViewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategory = new Category();
            newCategory.Id = categoryViewModel.Id;
            newCategory.Name = categoryViewModel.Name;

            return newCategory;
        }
    }
}