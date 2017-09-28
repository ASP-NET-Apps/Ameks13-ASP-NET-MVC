using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Pure.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface ICategoryServiceCopy
    {
        IEnumerable<CategoryModel> GetAllCategories();

        IEnumerable<CategoryModel> GetAllCategoriesSortedById();

        IEnumerable<CategoryModel> GetAllCategoriesSortedByName();

        CategoryModel GetCategoryById(int? id);

        ICategory InsertCategory(CategoryModel categoryModel);

        ICategory UpdateCategory(CategoryModel categoryModel);

        void DeleteCategoryById(int? id);
    }
}
