using MyWoodenHouse.Data.Models.Contracts;
using MyWoodenHouse.Data.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Data.Models
{
    [MetadataType(typeof(MaterialMetaData))]
    public partial class Material : IMaterial
    {
    }
}
