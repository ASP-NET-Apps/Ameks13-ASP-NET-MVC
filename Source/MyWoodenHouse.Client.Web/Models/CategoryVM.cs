using MyWoodenHouse.Data.Models.Contracts;
using MyWoodenHouse.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWoodenHouse.Models
{
    public class CategoryVM : ICategoryVM
    {
        public CategoryVM()
        {
            this.Id = 0;
        }

        public CategoryVM(ICategory category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}