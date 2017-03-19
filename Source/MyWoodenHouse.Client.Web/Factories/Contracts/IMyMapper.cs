using MyWoodenHouse.Data.Models.Contracts;
using MyWoodenHouse.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Factories.Contracts
{
    public interface IMyMapper
    {
        ICategoryVM CreateCategoryVM(ICategory category);
    }
}
