using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface IPicture
    {
        string Name { get; set; }

        int? Width { get; set; }

        int? Height { get; set; }

        byte[] FileContent { get; set; }

        string Url { get; set; }

        int GetFrom { get; set; }

        ICollection<Building> Buildings { get; set; }
    }
}
