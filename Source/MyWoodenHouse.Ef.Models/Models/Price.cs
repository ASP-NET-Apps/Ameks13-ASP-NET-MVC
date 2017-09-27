using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models
{
    [MetadataType(typeof(PriceMetaData))]
    public partial class Price : IPriceEf
    {
    }
}
