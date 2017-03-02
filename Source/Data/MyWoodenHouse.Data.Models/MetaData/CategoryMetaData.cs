using MyWoodenHouse.Data.Models.Constants.Models;
using MyWoodenHouse.Data.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Data.Models.MetaData
{
    public class CategoryMetaData : ICategory
    {
        [Key]
        [Range(Consts.Category.Id.MinValue, Consts.Category.Id.MaxValue, ErrorMessage = Consts.Category.Id.ErrorMessage)]        
        public int Id { get; set; }

        [Required]        
        [MaxLength(Consts.Category.Name.MaxLength, ErrorMessage = Consts.Category.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Category.Name.MinLength, ErrorMessage = Consts.Category.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}
