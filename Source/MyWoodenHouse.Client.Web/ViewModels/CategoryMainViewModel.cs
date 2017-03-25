using MyWoodenHouse.Client.Web.ViewModels.Contracts;
using MyWoodenHouse.Pure.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Client.Web.ViewModels
{
    public class CategoryMainViewModel : ICategoryMainViewModel
    {
        public CategoryMainViewModel()
        {
            this.Id = 0;
        }

        public CategoryMainViewModel(CategoryModel categoryModel)
        {
            this.Id = categoryModel.Id;
            this.Name = categoryModel.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Category")]
        public string ModelName { get; set; }
    }
}