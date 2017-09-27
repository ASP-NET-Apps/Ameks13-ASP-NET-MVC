using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Contracts.Models
{
    public interface IPicture
    {
        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        string PictureUrl { get; set; }
    }
}
