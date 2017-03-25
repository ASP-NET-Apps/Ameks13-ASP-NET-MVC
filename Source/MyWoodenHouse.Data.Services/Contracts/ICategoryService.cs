using MyWoodenHouse.Contracts.PureModels;
using MyWoodenHouse.Pure.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAllCategories();

        IEnumerable<CategoryModel> GetAllCategoriesSortedById();

        IEnumerable<CategoryModel> GetAllCategoriesSortedByName();

        ICategoryModel InsertCategory(CategoryModel categoryModel);
    }
}
