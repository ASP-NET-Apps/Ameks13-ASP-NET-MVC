using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface IMaterial
    {
        string Name { get; set; }

        string Description { get; set; }

        ICollection<Building> Buildings { get; set; }
    }
}
