﻿using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class CategoryMetaData : ICategoryEf
    {
        [Key]
        [Display(Name = "Id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(Consts.Category.Id.MinValue, Consts.Category.Id.MaxValue, ErrorMessage = Consts.Category.Id.ErrorMessage)]        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Category.Name.MaxLength, ErrorMessage = Consts.Category.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Category.Name.MinLength, ErrorMessage = Consts.Category.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}
