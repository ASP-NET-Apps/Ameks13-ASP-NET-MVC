using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Abstract;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings
{
    public class BuildingCompleteVm : DataModelVm, IBuildingCompleteVm
    {
        public BuildingCompleteVm()
        {
        }

        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Building.Id.MinValue, Consts.Building.Id.MaxValue, ErrorMessage = Consts.Building.Id.ErrorMessage)]
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

        public CategoryCompleteVm Category { get; set; }

        [Required]
        public int ProductId { get; set; }
                
        public ProductCompleteVm Product { get; set; }

        [Display(Name = "Materials")]
        public ICollection<MaterialCompleteVm> Materials { get; set; }

        [Display(Name = "Pictures")]
        public ICollection<PictureCompleteVm> Pictures { get; set; }

        [Display(Name = "Building")]
        public string ModelName { get; set; }

    }
}