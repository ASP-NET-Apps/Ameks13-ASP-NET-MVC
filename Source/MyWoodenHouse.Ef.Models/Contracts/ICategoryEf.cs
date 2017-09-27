using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface ICategoryEf : ICategory, IHasIntId
    {
        ICollection<Building> Buildings { get; set; }
    }
}
