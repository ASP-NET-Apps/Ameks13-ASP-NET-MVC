using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Contracts.PureModels
{
    public interface IPictureModel
    {
        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        string PictureUrl { get; set; }
    }
}
