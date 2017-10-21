using MyWoodenHouse.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface IPictureService
    {
        IEnumerable<Picture> GetAllSortedById();

        IEnumerable<Picture> GetAllSortedByName();
    }
}
