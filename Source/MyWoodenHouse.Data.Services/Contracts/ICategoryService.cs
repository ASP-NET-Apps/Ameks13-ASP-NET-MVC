using MyWoodenHouse.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllSortedById();

        IEnumerable<Category> GetAllSortedByName();
    }
}
