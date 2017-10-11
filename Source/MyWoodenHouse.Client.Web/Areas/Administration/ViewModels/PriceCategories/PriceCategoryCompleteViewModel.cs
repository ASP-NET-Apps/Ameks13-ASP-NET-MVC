using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.PriceCategories
{
    public class PriceCategoryCompleteViewModel : IPriceCategoryCompleteViewModel
    {
        public PriceCategoryCompleteViewModel()
        {
        }

        public PriceCategoryCompleteViewModel(IPriceCategory category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        [Display(Name = "Id")]
        [Range(Consts.PriceCategory.Id.MinValue, Consts.PriceCategory.Id.MaxValue, ErrorMessage = Consts.PriceCategory.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.PriceCategory.Name.MaxLength, ErrorMessage = Consts.PriceCategory.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.PriceCategory.Name.MinLength, ErrorMessage = Consts.PriceCategory.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Price Category")]
        public string ModelName { get; set; }
    }
}