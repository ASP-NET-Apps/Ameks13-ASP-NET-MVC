using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models.MetaData
{
    public class PriceCategoryMetaData : DataModel, IPriceCategory
    {
        [Required]
        [MaxLength(Consts.PriceCategory.Name.MaxLength, ErrorMessage = Consts.PriceCategory.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.PriceCategory.Name.MinLength, ErrorMessage = Consts.PriceCategory.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        public ICollection<Price> Prices { get; set; }
    }
}
