using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models
{
    [MetadataType(typeof(MaterialMetaData))]
    public partial class Material : IMaterialEf
    {
    }
}
