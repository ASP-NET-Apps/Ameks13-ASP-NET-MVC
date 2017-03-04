using System;
using MyWoodenHouse.Data.Models.Contracts;

namespace MyWoodenHouse.Data.Models
{
    public partial class Category : ICategory
    {
        public string ModelName { get; set; }
    }
}
