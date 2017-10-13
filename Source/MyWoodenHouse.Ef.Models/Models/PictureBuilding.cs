using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using System;

namespace MyWoodenHouse.Ef.Models
{
    [MetadataType(typeof(PictureBuildingMetaData))]
    public partial class PictureBuilding : IPictureBuildingEf
    {
        public int BuildingId { get; set; }

        public int PictureId { get; set; }
    }
}
