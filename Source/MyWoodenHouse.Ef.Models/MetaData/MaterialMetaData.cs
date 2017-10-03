using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class MaterialMetaData : IMaterialEf, IMaterial
    {
        [Key]
        [Display(Name = "Id")]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int Id { get; set; }

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
