using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using MyWoodenHouse.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models
{
    [MetadataType(typeof(MaterialMetaData))]
    public partial class Material : IHasIntId, IAuditable, IDeletable, IMaterial
    {
    }
}
