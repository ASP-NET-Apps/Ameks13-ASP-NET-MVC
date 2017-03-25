using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Contracts.PureModels
{
    public interface IBuildingModel
    {
        Nullable<float> UsableArea { get; set; }

        Nullable<float> BuiltUpArea { get; set; }

        Nullable<int> FloorsCount { get; set; }

        Nullable<int> RoomsCount { get; set; }

        Nullable<int> BathroomsCount { get; set; }        
    }
}
