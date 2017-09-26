using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWoodenHouse.Contracts.PureModels;
using MyWoodenHouse.Contracts;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IProduct: IProductModel, IHasIntId
    {
        ICollection<Building> Buildings { get; set; }

        ICollection<Price> Prices { get; set; }
    }
}
