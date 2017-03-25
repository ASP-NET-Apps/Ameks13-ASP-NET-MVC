using MyWoodenHouse.Client.Web.ViewModels;
using MyWoodenHouse.Pure.Models;

namespace MyWoodenHouse.Client.Web.Factories.Contracts
{
    public interface IMyViewModelsMapper
    {
        CategoryMainViewModel CategoryModel2CategoryViewModel(CategoryModel category);

        CategoryModel CategoryViewModel2CategoryModel(CategoryMainViewModel category);
    }
}
