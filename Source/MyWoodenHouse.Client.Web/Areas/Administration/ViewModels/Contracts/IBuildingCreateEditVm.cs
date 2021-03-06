﻿using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IBuildingCreateEditVm
    {
        BuildingCompleteVm BuildingCompleteVm { get; set; }

        SelectList CategoryList { get; set; }

        SelectList ProductList { get; set; }

        SelectList MaterialList { get; set; }

        IEnumerable<int> SelectedMaterialIdList { get; set; }

        SelectList PictureList { get; set; }

        IEnumerable<int> SelectedPictureIdList { get; set; }

        string ModelName { get; set; }
    }
}
