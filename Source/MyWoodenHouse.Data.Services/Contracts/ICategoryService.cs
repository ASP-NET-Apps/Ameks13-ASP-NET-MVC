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

        CategoryModel GetCategoryById(int? id);

        ICategoryModel InsertCategory(CategoryModel categoryModel);

        ICategoryModel UpdateCategory(CategoryModel categoryModel);

        void DeleteCategoryById(int? id);
    }
}
