using MyWoodenHouse.Client.Web.ViewModels.Categories;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.MyMappers.Contracts
{
    public interface IMyViewModelsMapper
    {
        CategoryMainViewModel Category2CategoryViewModel(Category category);

        Category CategoryViewModel2Category(CategoryMainViewModel category);
    }
}
