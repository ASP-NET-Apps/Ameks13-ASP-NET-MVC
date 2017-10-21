using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWoodenHouse.Models
{
    public partial class PictureBuilding : IPictureBuilding
    {
        [Key]
        [Column(Order = 1)]
        [Range(Consts.Building.Id.MinValue, Consts.Building.Id.MaxValue, ErrorMessage = Consts.Building.Id.ErrorMessage)]
        public int BuildingId { get; set; }

        [Key]
        [Column(Order = 2)]
        [Range(Consts.Picture.Id.MinValue, Consts.Picture.Id.MaxValue, ErrorMessage = Consts.Picture.Id.ErrorMessage)]
        public int PictureId { get; set; }

        public Building Building { get; set; }

        public Picture Picture { get; set; }
    }
}
