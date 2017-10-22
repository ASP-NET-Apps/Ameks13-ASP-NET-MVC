using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using MyWoodenHouse.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models
{
    [MetadataType(typeof(PictureMetaData))]
    public partial class Picture : IHasIntId, IAuditable, IDeletable, IPicture
    {
    }
}
