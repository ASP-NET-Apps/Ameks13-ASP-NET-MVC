using MyWoodenHouse.Client.Web.ViewModels.Contracts;
using MyWoodenHouse.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWoodenHouse.Client.Web.ViewModels
{
    public class CategoryViewModel : ICategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Id = 0;
        }

        public CategoryViewModel(ICategory category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}