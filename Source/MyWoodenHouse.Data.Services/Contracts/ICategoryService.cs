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

        int InsertCategory(CategoryModel categoryModel);

        CategoryModel UpdateCategory(CategoryModel categoryModel);

        void DeleteCategoryById(int? id);
    }
}
