using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class BuildingMetaData : IBuildingEf
    {
        [Key]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int Id { get; set; }
        
        public float? UsableArea { get; set; }

        public float? BuiltUpArea { get; set; }

        public int? RoomsCount { get; set; }

        public int? FloorsCount { get; set; }

        public int? BathroomsCount { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public ICollection<Material> Materials { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
