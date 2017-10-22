using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using MyWoodenHouse.Models.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IHasIntId, IAuditable, IDeletable, IProduct 
    {
    }
}
