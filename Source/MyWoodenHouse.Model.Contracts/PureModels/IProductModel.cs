using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Contracts.PureModels
{
    public interface IProductModel
    {
        string Name { get; set; }

        string Description { get; set; }
    }
}
