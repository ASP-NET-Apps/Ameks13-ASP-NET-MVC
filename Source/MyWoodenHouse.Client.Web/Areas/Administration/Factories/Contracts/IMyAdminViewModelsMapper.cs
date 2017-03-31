using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Pure.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts
{
    public interface IMyAdminViewModelsMapper
    {
        AdminCategoryMainViewModel CategoryModel2AdminCategoryViewModel(CategoryModel category);

        CategoryModel AdminCategoryViewModel2CategoryModel(AdminCategoryMainViewModel category);
    }
}
