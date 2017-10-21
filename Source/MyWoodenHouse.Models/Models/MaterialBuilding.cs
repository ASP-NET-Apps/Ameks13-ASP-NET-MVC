using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWoodenHouse.Models
{
    public partial class MaterialBuilding : IMaterialBuilding
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
