using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using MyWoodenHouse.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models
{
    [MetadataType(typeof(PriceMetaData))]
    public partial class Price : IHasIntId, IAuditable, IDeletable, IPrice
    {
    }
}
