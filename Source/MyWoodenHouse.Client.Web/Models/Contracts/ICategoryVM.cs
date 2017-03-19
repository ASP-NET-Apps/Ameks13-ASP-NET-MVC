using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Models.Contracts
{
    public interface ICategoryVM
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
