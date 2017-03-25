using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class PriceCategoryMetaData : IPriceCategory
    {
        [Key]
        [Range(Consts.PriceCategory.Id.MinValue, Consts.PriceCategory.Id.MaxValue, ErrorMessage = Consts.PriceCategory.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [MaxLength(Consts.PriceCategory.Name.MaxLength, ErrorMessage = Consts.PriceCategory.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.PriceCategory.Name.MinLength, ErrorMessage = Consts.PriceCategory.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        public ICollection<Price> Prices { get; set; }
    }
}
