using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Abstract;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels
{
    public class PriceCompleteVm : DataModelVm, IPriceCompleteVm
    {
        public PriceCompleteVm()
        {
        }

        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Price.Id.MinValue, Consts.Price.Id.MaxValue, ErrorMessage = Consts.Price.Id.ErrorMessage)]
        public int Id { get; set; }

        [Range(Consts.Price.Value.MinValue, Consts.Price.Value.MaxValue, ErrorMessage = Consts.Price.Value.ErrorMessage)]
        public float? Value { get; set; }

        [Required]
        [Display(Name = "Currency")]
        [MaxLength(Consts.Price.Currency.MaxLength, ErrorMessage = Consts.Price.Currency.ErrorMessageMaxLength)]
        [MinLength(Consts.Price.Currency.MinLength, ErrorMessage = Consts.Price.Currency.ErrorMessageMinLength)]
        public string Currency { get; set; }

        [Display(Name = "Per Square Meter")]
        [Range(Consts.Price.PerSquareMeter.MinValue, Consts.Price.PerSquareMeter.MaxValue, ErrorMessage = Consts.Price.PerSquareMeter.ErrorMessage)]
        public float PerSquareMeter { get; set; }

        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Price.Id.MinValue, Consts.Price.Id.MaxValue, ErrorMessage = Consts.Price.Id.ErrorMessage)]
        public int PriceCategoryId { get; set; }

        [Display(Name = "Price")]
        public string ModelName { get; set; }
    }
}