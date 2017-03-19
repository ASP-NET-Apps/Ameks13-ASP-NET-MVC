using MyWoodenHouse.Data.Models.Contracts;
using MyWoodenHouse.Models;
using MyWoodenHouse.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWoodenHouse.Factories
{
    public class MyMapper
    {
        public MyMapper()
        {
        }

        public ICategoryVM CreateCategoryVM(ICategory category)
        {
            var newCategoryVM = new CategoryVM(category);

            return newCategoryVM;
        }
    }
}