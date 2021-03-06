﻿using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWoodenHouse.Models.MetaData
{
    public class BuildingMetaData : DataModel, IBuilding
    {
        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Building.Name.MaxLength, ErrorMessage = Consts.Building.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Building.Name.MinLength, ErrorMessage = Consts.Building.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Building.Description.MaxLength, ErrorMessage = Consts.Building.Name.ErrorMessageMaxLength)]
        public string Description { get; set; }

        [Range(Consts.Building.UsableArea.MinValue, Consts.Building.UsableArea.MaxValue, ErrorMessage = Consts.Building.UsableArea.ErrorMessage)]
        public float? UsableArea { get; set; }

        [Range(Consts.Building.BuiltUpArea.MinValue, Consts.Building.BuiltUpArea.MaxValue, ErrorMessage = Consts.Building.BuiltUpArea.ErrorMessage)]
        public float? BuiltUpArea { get; set; }

        [Range(Consts.Building.RoomsCount.MinValue, Consts.Building.RoomsCount.MaxValue, ErrorMessage = Consts.Building.RoomsCount.ErrorMessage)]
        public int? RoomsCount { get; set; }

        [Range(Consts.Building.FloorsCount.MinValue, Consts.Building.FloorsCount.MaxValue, ErrorMessage = Consts.Building.FloorsCount.ErrorMessage)]
        public int? FloorsCount { get; set; }

        [Range(Consts.Building.BathroomsCount.MinValue, Consts.Building.BathroomsCount.MaxValue, ErrorMessage = Consts.Building.BathroomsCount.ErrorMessage)]
        public int? BathroomsCount { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public ICollection<Material> Materials { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
