using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Contracts.PureModels
{
    public interface IPriceModel
    {
        Nullable<float> Value { get; set; }

        string Currency { get; set; }
    }
}
