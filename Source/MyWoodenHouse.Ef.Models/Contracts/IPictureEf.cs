using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.Models;
using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IPictureEf : IPicture, IHasIntId
    {
        ICollection<Building> Buildings { get; set; }
    }
}
