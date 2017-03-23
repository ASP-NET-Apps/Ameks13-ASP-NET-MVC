using MyWoodenHouse.Client.Web.ViewModels;
using MyWoodenHouse.Data.Models.Contracts;

namespace MyWoodenHouse.Client.Web.Factories.Contracts
{
    public interface IMyMapper
    {
        CategoryViewModel CreateCategoryViewModel(ICategory category);
    }
}
