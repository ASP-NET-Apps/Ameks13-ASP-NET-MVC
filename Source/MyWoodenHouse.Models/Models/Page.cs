using MyWoodenHouse.Models.Contracts;
using MyWoodenHouse.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models
{
    [MetadataType(typeof(PageMetaData))]
    public partial class Page : IHasIntId, IAuditable, IDeletable, IPage
    {
    }
}
