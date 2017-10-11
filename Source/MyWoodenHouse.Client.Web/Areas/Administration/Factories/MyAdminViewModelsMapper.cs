using System;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class MyAdminViewModelsMapper : IMyAdminViewModelsMapper
    {
        public AdminCategoryMainViewModel Category2AdminCategoryViewModel(Category category)
        {
            if (category == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newAdminCategoryViewModel = new AdminCategoryMainViewModel(category);

            return newAdminCategoryViewModel;
        }

        public Category AdminCategoryViewModel2Category(AdminCategoryMainViewModel adminCategoryViewModel)
        {
            if (adminCategoryViewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategory = new Category();
            newCategory.Id = adminCategoryViewModel.Id;
            newCategory.Name = adminCategoryViewModel.Name;

            return newCategory;
        }
    }
}