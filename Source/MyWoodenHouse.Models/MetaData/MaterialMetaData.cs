using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models.MetaData
{
    public class MaterialMetaData : DataModel, IMaterial
    {
        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Material.Name.MaxLength, ErrorMessage = Consts.Material.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Material.Name.MinLength, ErrorMessage = Consts.Material.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Material.Description.MaxLength, ErrorMessage = Consts.Material.Name.ErrorMessageMaxLength)]
        public string Description { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}
