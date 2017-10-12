﻿using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings
{
    public class BuildingCreateEditViewModel : IBuildingCreateEditViewModel
    {
        private IBuildingCompleteViewModel buildingCompleteViewModel;

        public BuildingCreateEditViewModel()
        {
            this.buildingCompleteViewModel = new BuildingCompleteViewModel();
        }

        public BuildingCreateEditViewModel(BuildingCompleteViewModel buildingCompleteViewModel)
        {
            // Todo add validation
            this.BuildingCompleteViewModel = buildingCompleteViewModel;
        }
         
        public IBuildingCompleteViewModel BuildingCompleteViewModel
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

        [Display(Name = "Building")]
        public string ModelName { get; set; }

    }
}