using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWoodenHouse.Ef.Models;
using System.ComponentModel.DataAnnotations;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Ef.Models.Contracts;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings
{
    public class BuildingCompleteViewModel : IBuildingCompleteViewModel
    {
        public BuildingCompleteViewModel()
        {
        }

        public BuildingCompleteViewModel(IBuildingEf building)
        {
            this.Id = building.Id;
            this.Name = building.Name;
            this.Description = building.Description;

            this.UsableArea = building.UsableArea;
            this.BuiltUpArea = building.BuiltUpArea;
            this.RoomsCount = building.RoomsCount;
            this.FloorsCount = building.FloorsCount;
            this.BathroomsCount = building.BathroomsCount;

            this.CategoryId = building.CategoryId;
            this.Category = building.Category;
            this.ProductId = building.ProductId;
            this.Product = building.Product;

            this.Materials = new HashSet<Material>();
            this.Pictures = new HashSet<Picture>();

            //if(building.Materials.Count > 0)
            //{
            //    this.Materials = building.Materials;
            //}
            //if(building.Pictures.Count > 0)
            //{
            //    this.Pictures = building.Pictures;
            //}

        }

        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int Id { get; set; }

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

        public Category Category { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public ICollection<Material> Materials { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        [Display(Name = "Building")]
        public string ModelName { get; set; }

    }
}