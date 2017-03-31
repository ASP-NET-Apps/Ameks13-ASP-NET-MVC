using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Pure.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories
{
    public class AdminCategoryMainViewModel : IAdminCategoryMainViewModel
    {
        public AdminCategoryMainViewModel()
        {
            this.Id = 0;
        }

        public AdminCategoryMainViewModel(CategoryModel categoryModel)
        {
            this.Id = categoryModel.Id;
            this.Name = categoryModel.Name;
        }

        [Display(Name = "Id")]
        [Range(Consts.Category.Id.MinValue, Consts.Category.Id.MaxValue, ErrorMessage = Consts.Category.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Category.Name.MaxLength, ErrorMessage = Consts.Category.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Category.Name.MinLength, ErrorMessage = Consts.Category.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public string ModelName { get; set; }
    }
}