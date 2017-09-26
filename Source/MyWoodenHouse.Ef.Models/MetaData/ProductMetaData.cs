using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class ProductMetaData : IProduct
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

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
