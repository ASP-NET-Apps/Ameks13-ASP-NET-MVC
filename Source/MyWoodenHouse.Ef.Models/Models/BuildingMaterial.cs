﻿using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models
{
    [MetadataType(typeof(MaterialBuildingMetaData))]
    public partial class MaterialBuilding : IMaterialBuildingEf
    {
        public int BuildingId { get; set; }

        public int MaterialId { get; set; }
    }
}
