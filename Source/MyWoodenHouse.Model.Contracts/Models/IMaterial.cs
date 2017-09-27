using System.Collections.Generic;

namespace MyWoodenHouse.Contracts.Models
{
    public interface IMaterial : IHasIntId
    {
        string Name { get; set; }

        string Description { get; set; }
    }
}
