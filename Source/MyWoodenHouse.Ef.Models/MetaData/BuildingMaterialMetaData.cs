using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class MaterialBuildingMetaData : IMaterialBuildingEf
    {      
        [Key]
        [Range(Consts.Building.Id.MinValue, Consts.Building.Id.MaxValue, ErrorMessage = Consts.Building.Id.ErrorMessage)]
        public int BuildingId { get; set; }

        [Key]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int MaterialId { get; set; }

        public Material Material { get; set; }

        public Building Building { get; set; }
    }
}
