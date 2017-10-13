using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Ef.Models;
using Ninject;
using System;
using System.Linq;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class BuildingModelMapper : IGenericModelMapper<Building, BuildingCompleteViewModel>
    {
        private readonly IGenericModelMapper<Category, CategoryCompleteViewModel> categoryModelMapper;
        private readonly IGenericModelMapper<Product, ProductCompleteViewModel> productModelMapper;
        private readonly IGenericModelMapper<Material, MaterialCompleteViewModel> materialModelMapper;
        private readonly IGenericModelMapper<Picture, PictureCompleteViewModel> pictureModelMapper;

        public BuildingModelMapper()
        {
            this.categoryModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Category, CategoryCompleteViewModel>>();
            this.productModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Product, ProductCompleteViewModel>>();
            this.materialModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Material, MaterialCompleteViewModel>>();
            this.pictureModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Picture, PictureCompleteViewModel>>();
        }

        public BuildingCompleteViewModel Model2ViewModel(Building model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new BuildingCompleteViewModel();
            
            viewModelToReturn.Id = model.Id;
            viewModelToReturn.Name = model.Name;
            viewModelToReturn.Description = model.Description;

            viewModelToReturn.UsableArea = model.UsableArea;
            viewModelToReturn.BuiltUpArea = model.BuiltUpArea;
            viewModelToReturn.RoomsCount = model.RoomsCount;
            viewModelToReturn.FloorsCount = model.FloorsCount;
            viewModelToReturn.BathroomsCount = model.BathroomsCount;
            
            viewModelToReturn.CategoryId = model.CategoryId;
            viewModelToReturn.Category = this.categoryModelMapper.Model2ViewModel(model.Category);
            viewModelToReturn.ProductId = model.ProductId;
            viewModelToReturn.Product = this.productModelMapper.Model2ViewModel(model.Product);

            // TODO Add proper validation
            if (model.Materials != null)
            {
                if (model.Materials.Count > 0)
                {
                    viewModelToReturn.Materials = model.Materials.Select(m => this.materialModelMapper.Model2ViewModel(m)).ToList();
                }
            }

            // TODO Add proper validation
            if (model.Pictures != null)
            {
                if (model.Pictures.Count > 0)
                {
                    viewModelToReturn.Pictures = model.Pictures.Select(p => this.pictureModelMapper.Model2ViewModel(p)).ToList();
                }
            }

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

            // TODO Add proper validation
            if (viewModel.Category != null)
            {
                modelToReturn.Category = this.categoryModelMapper.ViewModel2Model(viewModel.Category);
            }

            modelToReturn.ProductId = viewModel.ProductId;

            // TODO Add proper validation
            if (viewModel.Product != null)
            {
                modelToReturn.Product = this.productModelMapper.ViewModel2Model(viewModel.Product);
            }

            // TODO Add proper validation
            if (viewModel.Materials != null)
            {
                if (viewModel.Materials.Count > 0)
                {
                    modelToReturn.Materials = viewModel.Materials.Select(m => this.materialModelMapper.ViewModel2Model(m)).ToList();
                }
            }

            // TODO Add proper validation
            if (viewModel.Pictures != null)
            {
                if (viewModel.Pictures.Count > 0)
                {
                    modelToReturn.Pictures = viewModel.Pictures.Select(p => this.pictureModelMapper.ViewModel2Model(p)).ToList();
                }
            }

            return modelToReturn;
        }
        
    }
}