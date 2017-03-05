using MyWoodenHouse.Data.Models.Contracts;
using MyWoodenHouse.Data.Models.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models
{
    [MetadataType(typeof(BuildingMetaData))]
    public partial class Building : IBuilding
    {
    }
}
