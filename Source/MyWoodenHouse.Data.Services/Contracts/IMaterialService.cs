using MyWoodenHouse.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface IMaterialService
    {
        IEnumerable<Material> GetAllSortedById();

        IEnumerable<Material> GetAllSortedByName();
    }
}
