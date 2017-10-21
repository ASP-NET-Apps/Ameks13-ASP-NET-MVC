using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface ICategory
    {
        string Name { get; set; }

        ICollection<Building> Buildings { get; set; }
    }
}
