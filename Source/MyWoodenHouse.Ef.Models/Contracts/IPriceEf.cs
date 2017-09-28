using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IPriceEf : IPrice, IHasIntId
    {
        PriceCategory PriceCategory { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
