using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWoodenHouse.Ef.Models;
using System.ComponentModel.DataAnnotations;
using MyWoodenHouse.Constants.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings
{
    public class BuildingCompleteViewModel : IBuildingCompleteViewModel
    {
        [Required]
        [Display(Name = "Id")]
        [Range(Consts.Material.Id.MinValue, Consts.Material.Id.MaxValue, ErrorMessage = Consts.Material.Id.ErrorMessage)]
        public int Id { get; set; }

        public float? UsableArea { get; set; }

        public float? BuiltUpArea { get; set; }

        public int? BathroomsCount { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public int? FloorsCount { get; set; }

        public ICollection<Material> Materials { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int? RoomsCount { get; set; }

    }
}