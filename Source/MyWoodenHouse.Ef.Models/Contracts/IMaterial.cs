using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.PureModels;
using System.Collections.Generic;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IMaterial : IMaterialModel, IHasIntId
    {
        ICollection<Building> Buildings { get; set; }
    }
}
