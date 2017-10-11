using MyWoodenHouse.Ef.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();

        IEnumerable<Category> GetAllCategoriesSortedById();

        IEnumerable<Category> GetAllCategoriesSortedByName();

        Category GetCategoryById(int? id);

        int InsertCategory(Category categoryModel);

        Category UpdateCategory(Category categoryModel);

        void DeleteCategoryById(int? id);
    }
}
