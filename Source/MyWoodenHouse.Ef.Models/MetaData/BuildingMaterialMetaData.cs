using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class BuildingMaterialMetaData : IBuildingMaterialEf
    {
        [Key]
        [Range(Consts.Building.Id.MinValue, Consts.Building.Id.MaxValue, ErrorMessage = Consts.Building.Id.ErrorMessage)]
        public int BuildingId { get; set; }

        [Key]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int MaterialId { get; set; }
    }
}
