using MyWoodenHouse.Data.Models.Contracts;
using MyWoodenHouse.Pure.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Pure.Models
{
    public class CategoryModel : ICategoryModel
    {
        public CategoryModel(ICategory category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
