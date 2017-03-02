using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models.Contracts
{
    public interface ICategory
    {        
        int Id { get; set; }

        string Name { get; set; }

        ICollection<Building> Buildings { get; set; }
    }
}
