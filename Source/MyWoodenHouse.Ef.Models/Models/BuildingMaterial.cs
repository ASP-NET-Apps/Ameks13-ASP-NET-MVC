using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyWoodenHouse.Ef.Models
{
    [MetadataType(typeof(MaterialBuildingMetaData))]
    public partial class MaterialBuilding : IMaterialBuildingEf
    {
        public Building Building { get; set; }

        public int BuildingId { get; set; }

        public Material Material { get; set; }

        public int MaterialId { get; set; }
    }
}
