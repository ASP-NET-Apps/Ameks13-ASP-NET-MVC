using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models.Contracts
{
    public interface IPrice
    {
        int Id { get; set; }

        Nullable<float> Value { get; set; }

        string Currency { get; set; }

        float PerSquareMeter { get; set; }

        int PriceCategory { get; set; }

        ICollection<Product> Products { get; set; }
    }
}
