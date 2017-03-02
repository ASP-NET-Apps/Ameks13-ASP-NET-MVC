using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Data.Models.Contracts
{
    public interface IPicture
    {
        int Id { get; set; }

        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        byte[] PictureContent { get; set; }

        string PictureUrl { get; set; }

        ICollection<Building> Buildings { get; set; }
    }
}
