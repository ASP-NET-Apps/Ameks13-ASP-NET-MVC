using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using MyWoodenHouse.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models
{
    [MetadataType(typeof(PriceCategoryMetaData))]
    public partial class PriceCategory : IHasIntId, IAuditable, IDeletable, IPriceCategory
    {
    }
}
