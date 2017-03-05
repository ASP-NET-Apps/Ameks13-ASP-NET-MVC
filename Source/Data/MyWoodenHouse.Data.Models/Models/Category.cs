using System;
using MyWoodenHouse.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using MyWoodenHouse.Data.Models.MetaData;

namespace MyWoodenHouse.Data.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category : ICategory
    {
        public string ModelName { get; set; }
    }
}
