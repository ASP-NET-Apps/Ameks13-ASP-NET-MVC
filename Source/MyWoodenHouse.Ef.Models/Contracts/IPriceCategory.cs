﻿using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.PureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IPriceCategory : IPriceCategoryModel, IHasIntId
    {
        ICollection<Price> Prices { get; set; }
    }
}