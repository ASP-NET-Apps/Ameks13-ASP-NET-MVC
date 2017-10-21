using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models.MetaData
{
    public class ProductMetaData : DataModel, IProduct
    {
        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Product.Name.MaxLength, ErrorMessage = Consts.Product.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Product.Name.MinLength, ErrorMessage = Consts.Product.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Material.Name.MaxLength, ErrorMessage = Consts.Material.Name.ErrorMessageMaxLength)]
        public string Description { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public ICollection<Price> Prices { get; set; }
    }
}
