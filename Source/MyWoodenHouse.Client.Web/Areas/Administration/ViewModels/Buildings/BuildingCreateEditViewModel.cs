using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System;
using MyWoodenHouse.Ef.Models;
using System.Collections.Generic;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings
{
    public class BuildingCreateEditViewModel : IBuildingCreateEditViewModel
    {
        private BuildingCompleteViewModel buildingCompleteViewModel;

        public BuildingCreateEditViewModel()
        {
        }

        public BuildingCreateEditViewModel(BuildingCompleteViewModel buildingCompleteViewModel)
        {
            // Todo add validation
            this.BuildingCompleteViewModel = buildingCompleteViewModel;
        }
         
        public BuildingCompleteViewModel BuildingCompleteViewModel
        {
            get
            {
                return this.buildingCompleteViewModel;
            }
            set
            {
                this.buildingCompleteViewModel = value;
            }
        }

        public SelectList CategoryList { get; set; }

        public SelectList ProductList { get; set; }
        
        public SelectList MaterialList { get; set; }

        public IEnumerable<int> SelectedMaterialIdList { get; set; }
        
        [Display(Name = "Building")]
        public string ModelName { get; set; }
    }
}