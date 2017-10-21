using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface IBuilding
    {
        string Name { get; set; }

        string Description { get; set; }

        float? UsableArea { get; set; }

        float? BuiltUpArea { get; set; }

        int? FloorsCount { get; set; }

        int? RoomsCount { get; set; }

        int? BathroomsCount { get; set; }

        int CategoryId { get; set; }

        Category Category { get; set; }

        int ProductId { get; set; }

        Product Product { get; set; }

        ICollection<Material> Materials { get; set; }

        ICollection<Picture> Pictures { get; set; }
    }
}
