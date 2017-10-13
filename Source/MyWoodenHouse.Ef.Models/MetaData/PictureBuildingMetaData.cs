using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class PictureBuildingMetaData : IPictureBuildingEf
    {
        [Key]
        [Range(Consts.Building.Id.MinValue, Consts.Building.Id.MaxValue, ErrorMessage = Consts.Building.Id.ErrorMessage)]
        public int BuildingId { get; set; }

        [Key]
        [Range(Consts.Picture.Id.MinValue, Consts.Picture.Id.MaxValue, ErrorMessage = Consts.Picture.Id.ErrorMessage)]
        public int PictureId { get; set; }
    }
}
