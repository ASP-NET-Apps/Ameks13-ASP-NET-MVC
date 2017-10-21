using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface IPrice
    {
        float? Value { get; set; }

        string Currency { get; set; }

        float PerSquareMeter { get; set; }

        int PriceCategoryId { get; set; }

        PriceCategory PriceCategory { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
