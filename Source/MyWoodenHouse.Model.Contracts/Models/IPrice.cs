using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Contracts.Models
{
    public interface IPrice : IHasIntId
    {        
        Nullable<float> Value { get; set; }

        string Currency { get; set; }

        float PerSquareMeter { get; set; }

        int PriceCategoryId { get; set; }
    }
}
