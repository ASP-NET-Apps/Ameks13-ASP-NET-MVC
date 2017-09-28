﻿using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.PureModels;
using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IPictureEf : IPictureModel, IHasIntId
    {
        byte[] PictureContent { get; set; }

        ICollection<Building> Buildings { get; set; }
    }
}