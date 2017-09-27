using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Contracts.Models
{
    public interface ICategory : IHasIntId
    {
        string Name { get; set; }
    }
}
