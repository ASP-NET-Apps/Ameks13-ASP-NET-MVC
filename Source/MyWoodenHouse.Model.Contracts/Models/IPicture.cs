using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Contracts.Models
{
    public interface IPicture : IHasIntId
    {
        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        byte[] PictureContent { get; set; }

        string PictureUrl { get; set; }

        
    }
}
