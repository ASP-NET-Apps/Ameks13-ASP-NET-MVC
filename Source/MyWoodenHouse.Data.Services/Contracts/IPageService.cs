using MyWoodenHouse.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface IPageService
    {
        IEnumerable<Page> GetAllSortedById();

        IEnumerable<Page> GetAllSortedByName();
    }
}
