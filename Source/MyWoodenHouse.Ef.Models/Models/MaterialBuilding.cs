using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using System;
using MyWoodenHouse.Constants.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWoodenHouse.Ef.Models
{    
    public partial class MaterialBuilding : IMaterialBuildingEf
    {        
        [Key]
        [Column(Order = 1)]
        [Range(Consts.Building.Id.MinValue, Consts.Building.Id.MaxValue, ErrorMessage = Consts.Building.Id.ErrorMessage)]
        public int BuildingId { get; set; }

        [Key]
        [Column(Order = 2)]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int MaterialId { get; set; }

        public Building Building { get; set; }

        public Material Material { get; set; }
                
    }
}
