﻿using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Material
{
    public class MaterialCompleteViewModel
    {
        public MaterialCompleteViewModel()
        {
        }

        public MaterialCompleteViewModel(IMaterial material)
        {
            this.Id = material.Id;
            this.Name = material.Name;
            this.Description = material.Description;
        }

        [Display(Name = "Id")]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Material.Name.MaxLength, ErrorMessage = Consts.Material.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Material.Name.MinLength, ErrorMessage = Consts.Material.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Material.Name.MaxLength, ErrorMessage = Consts.Material.Name.ErrorMessageMaxLength)]
        public string Description { get; set; }


    }
}