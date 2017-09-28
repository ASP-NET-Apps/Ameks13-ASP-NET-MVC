using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IMaterialEf : IMaterial, IHasIntId
    {
        ICollection<Building> Buildings { get; set; }
    }
}
