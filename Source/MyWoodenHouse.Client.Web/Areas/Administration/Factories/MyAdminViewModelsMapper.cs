using System;
using MyWoodenHouse.Pure.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class MyAdminViewModelsMapper : IMyAdminViewModelsMapper
    {
        public AdminCategoryMainViewModel CategoryModel2AdminCategoryViewModel(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newAdminCategoryViewModel = new AdminCategoryMainViewModel(categoryModel);

            return newAdminCategoryViewModel;
        }

        public CategoryModel AdminCategoryViewModel2CategoryModel(AdminCategoryMainViewModel adminCategoryViewModel)
        {
            if (adminCategoryViewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var newCategoryModel = new CategoryModel();
            newCategoryModel.Id = adminCategoryViewModel.Id;
            newCategoryModel.Name = adminCategoryViewModel.Name;

            return newCategoryModel;
        }
    }
}