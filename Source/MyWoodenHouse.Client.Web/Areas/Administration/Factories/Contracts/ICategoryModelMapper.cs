using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Pure.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts
{
    public interface ICategoryModelMapper
    {
        CategoryModel CategoryCompleteViewModel2CategoryModel(CategoryCompleteViewModel categoryCompleteViewModel);
        CategoryCompleteViewModel CategoryModel2CategoryCompleteViewModel(CategoryModel categoryModel);
    }
}