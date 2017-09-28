using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.Models;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IBuildingEf : IBuilding, IHasIntId
    {
        int CategoryId { get; set; }

        Category Category { get; set; }

        int ProductId { get; set; }

        Product Product { get; set; }

        ICollection<Material> Materials { get; set; }

        ICollection<Picture> Pictures { get; set; }
    }
}
