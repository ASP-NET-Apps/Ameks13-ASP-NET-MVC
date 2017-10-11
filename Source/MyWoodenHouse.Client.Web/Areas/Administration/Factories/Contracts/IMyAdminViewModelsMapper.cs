using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts
{
    public interface IMyAdminViewModelsMapper
    {
        AdminCategoryMainViewModel Category2AdminCategoryViewModel(Category category);

        Category AdminCategoryViewModel2Category(AdminCategoryMainViewModel category);
    }
}
