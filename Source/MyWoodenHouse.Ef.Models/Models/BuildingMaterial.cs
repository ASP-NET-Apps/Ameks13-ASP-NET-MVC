using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models
{
    [MetadataType(typeof(BuildingMaterialMetaData))]
    public partial class BuildingMaterial : IBuildingMaterialEf
    {
        public int BuildingId { get; set; }

        public int MaterialId { get; set; }
    }
}
