using MyWoodenHouse.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class PriceMetaData : IPrice
    {
        [Key]
        public int Id { get; set; }

        public float? Value { get; set; }

        public string Currency { get; set; }

        public float PerSquareMeter { get; set; }

        public int PriceCategory { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
