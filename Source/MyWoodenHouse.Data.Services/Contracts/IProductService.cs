using MyWoodenHouse.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllSortedById();

        IEnumerable<Product> GetAllSortedByName();
    }
}
