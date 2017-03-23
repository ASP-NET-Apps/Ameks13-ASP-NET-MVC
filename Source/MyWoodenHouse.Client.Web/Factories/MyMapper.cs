using MyWoodenHouse.Client.Web.Factories.Contracts;
using MyWoodenHouse.Client.Web.ViewModels;
using MyWoodenHouse.Client.Web.ViewModels.Contracts;
using MyWoodenHouse.Data.Models.Contracts;

namespace MyWoodenHouse.Client.Web.Factories
{
    public class MyMapper : IMyMapper
    {
        public CategoryViewModel CreateCategoryViewModel(ICategory category)
        {
            var newCategoryVM = new CategoryViewModel(category);

            return newCategoryVM;
        }
    }
}