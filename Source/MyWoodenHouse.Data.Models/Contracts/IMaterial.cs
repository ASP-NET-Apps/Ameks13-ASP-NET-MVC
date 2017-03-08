using System.Collections.Generic;

namespace MyWoodenHouse.Data.Models.Contracts
{
    public interface IMaterial
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        ICollection<Building> Buildings { get; set; }
    }
}
