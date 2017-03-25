using MyWoodenHouse.Ef.Models.Contracts;
using MyWoodenHouse.Ef.Models.MetaData;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category : ICategory
    {
        public string ModelName { get; set; }
    }
}
