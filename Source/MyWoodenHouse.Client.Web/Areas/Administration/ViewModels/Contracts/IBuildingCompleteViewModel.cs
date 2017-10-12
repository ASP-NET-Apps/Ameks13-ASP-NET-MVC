﻿using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IBuildingCompleteViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        Nullable<float> UsableArea { get; set; }

        Nullable<float> BuiltUpArea { get; set; }

        Nullable<int> FloorsCount { get; set; }

        Nullable<int> RoomsCount { get; set; }

        Nullable<int> BathroomsCount { get; set; }
        
        int CategoryId { get; set; }

        Category Category { get; set; }

        int ProductId { get; set; }

        Product Product { get; set; }

        ICollection<Material> Materials { get; set; }

        ICollection<Picture> Pictures { get; set; }
    }
}