using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Contracts.Models
{
    public interface IPicture : IHasIntId
    {
        string Name { get; set; }

        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        byte[] FileContent { get; set; }

        string Url { get; set; }

        int GetFrom { get; set; }
    }
}
