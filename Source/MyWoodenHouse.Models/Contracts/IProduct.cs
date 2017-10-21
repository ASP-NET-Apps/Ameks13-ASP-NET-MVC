using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface IProduct
    {
        string Name { get; set; }

        string Description { get; set; }

        ICollection<Building> Buildings { get; set; }

        ICollection<Price> Prices { get; set; }
    }
}
