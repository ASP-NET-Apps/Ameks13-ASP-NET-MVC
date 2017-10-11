using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class BuildingModelMapper : IGenericModelMapper<Building, BuildingCompleteViewModel>
    {
        public BuildingCompleteViewModel Model2ViewModel(Building model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new BuildingCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Building ViewModel2Model(BuildingCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new Building();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;
            modelToReturn.Description = viewModel.Description;

            modelToReturn.UsableArea = viewModel.UsableArea;
            modelToReturn.BuiltUpArea = viewModel.BuiltUpArea;
            modelToReturn.FloorsCount = viewModel.FloorsCount;
            modelToReturn.RoomsCount = viewModel.RoomsCount;
            modelToReturn.BathroomsCount = viewModel.BathroomsCount;

            modelToReturn.CategoryId = viewModel.CategoryId;
            modelToReturn.Category = viewModel.Category;
            modelToReturn.ProductId = viewModel.ProductId;
            modelToReturn.Product = viewModel.Product;

            modelToReturn.Materials = viewModel.Materials;
            modelToReturn.Pictures = viewModel.Pictures;

            return modelToReturn;
        }
        
    }
}