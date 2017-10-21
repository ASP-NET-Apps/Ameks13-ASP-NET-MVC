using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System;
using MyWoodenHouse.Models;
using System.Collections.Generic;
using Bytes2you.Validation;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings
{
    public class BuildingCreateEditVm : IBuildingCreateEditVm
    {
        private BuildingCompleteVm buildingCompleteVm;

        public BuildingCreateEditVm()
        {
        }

        public BuildingCreateEditVm(BuildingCompleteVm buildingCompleteVm)
        {
            Guard.WhenArgument(buildingCompleteVm, nameof(buildingCompleteVm)).IsNull().Throw();

            this.BuildingCompleteVm = buildingCompleteVm;
        }
         
        public BuildingCompleteVm BuildingCompleteVm
        {
            get
            {
                return this.buildingCompleteVm;
            }
            set
            {
                this.buildingCompleteVm = value;
            }
        }

        public SelectList CategoryList { get; set; }

        public SelectList ProductList { get; set; }
        
        public SelectList MaterialList { get; set; }

        public IEnumerable<int> SelectedMaterialIdList { get; set; }

        public SelectList PictureList { get; set; }

        public IEnumerable<int> SelectedPictureIdList { get; set; }
        
        [Display(Name = "Building")]
        public string ModelName { get; set; }
    }
}