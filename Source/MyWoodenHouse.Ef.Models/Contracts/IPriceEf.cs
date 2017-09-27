using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.PureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IPriceEf : IPriceModel, IHasIntId
    {
        float PerSquareMeter { get; set; }

        int PriceCategory { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
