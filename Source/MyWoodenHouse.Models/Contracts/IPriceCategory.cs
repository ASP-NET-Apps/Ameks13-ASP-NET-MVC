using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface IPriceCategory
    {
        string Name { get; set; }

        ICollection<Price> Prices { get; set; }
    }
}
