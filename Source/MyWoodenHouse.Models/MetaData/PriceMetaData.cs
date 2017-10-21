using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWoodenHouse.Models.MetaData
{
    public class PriceMetaData : DataModel, IPrice
    {
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
        [Display(Name = "PriceCategoryId")]
        [Range(Consts.Price.PriceCategoryId.MinValue, Consts.Price.PriceCategoryId.MaxValue, ErrorMessage = Consts.Price.PriceCategoryId.ErrorMessage)]
        public int PriceCategoryId { get; set; }

        [ForeignKey("PriceCategoryId")]
        public PriceCategory PriceCategory { get; set; }

        [ForeignKey("Id")]
        public ICollection<Product> Products { get; set; }

        
    }
}
