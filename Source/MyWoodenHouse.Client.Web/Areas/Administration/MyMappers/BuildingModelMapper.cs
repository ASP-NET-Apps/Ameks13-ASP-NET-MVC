using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Ef.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class BuildingModelMapper : IGenericModelMapper<Building, BuildingCompleteViewModel>
    {
        private readonly IGenericModelMapper<ICategory, ICategoryCompleteViewModel> categoryModelMapper;
        private readonly IGenericModelMapper<IProduct, IProductCompleteViewModel> productModelMapper;
        private readonly IGenericModelMapper<IMaterial, IMaterialCompleteViewModel> materialModelMapper;
        private readonly IGenericModelMapper<IPicture, IPictureCompleteViewModel> pictureModelMapper;

        //public BuildingModelMapper()
        //{
        //    this.categoryModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Category, CategoryCompleteViewModel>>();
        //    this.productModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Product, ProductCompleteViewModel>>();
        //    this.materialModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Material, MaterialCompleteViewModel>>();
        //    this.pictureModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Picture, PictureCompleteViewModel>>();
        //}

        public BuildingModelMapper(IGenericModelMapper<ICategory, ICategoryCompleteViewModel> categoryModelMapper,
            IGenericModelMapper<IProduct, IProductCompleteViewModel> productModelMapper,
            IGenericModelMapper<IMaterial, IMaterialCompleteViewModel> materialModelMapper,
            IGenericModelMapper<IPicture, IPictureCompleteViewModel> pictureModelMapper)
        {
            this.categoryModelMapper = categoryModelMapper;
            this.productModelMapper = productModelMapper;
            this.materialModelMapper = materialModelMapper;
            this.pictureModelMapper = pictureModelMapper;
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
                    foreach (var material in model.Materials)
                    {
                        var m = this.materialModelMapper.Model2ViewModel(material);
                        viewModelToReturn.Materials.Add((MaterialCompleteViewModel)m);
                    }
                }
            }

            // TODO Add proper validation
            if (model.Pictures != null)
            {
                if (model.Pictures.Count > 0)
                {
                    foreach (var picture in model.Pictures)
                    {
                        var p = this.pictureModelMapper.Model2ViewModel(picture);
                        viewModelToReturn.Pictures.Add((PictureCompleteViewModel)p);
                    }
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
                var cat = this.categoryModelMapper.ViewModel2Model(viewModel.Category);
                modelToReturn.Category = null;
            }

            modelToReturn.ProductId = viewModel.ProductId;

            // TODO Add proper validation
            if (viewModel.Product != null)
            {
                var prod = this.productModelMapper.ViewModel2Model(viewModel.Product);
                modelToReturn.Product = null;
            }

            // TODO Add proper validation
            if (viewModel.Materials != null)
            {
                if (viewModel.Materials.Count > 0)
                {
                    foreach(var material in viewModel.Materials)
                    {
                        var m = this.materialModelMapper.ViewModel2Model(material);
                        modelToReturn.Materials.Add((Material)m); 
                    }
                }
            }

            // TODO Add proper validation
            if (viewModel.Pictures != null)
            {
                if (viewModel.Pictures.Count > 0)
                {
                    foreach (var picture in viewModel.Pictures)
                    {
                        var p = this.pictureModelMapper.ViewModel2Model(picture);
                        modelToReturn.Pictures.Add((Picture)p);
                    }
                }
            }

            return modelToReturn;
        }
        
    }
}