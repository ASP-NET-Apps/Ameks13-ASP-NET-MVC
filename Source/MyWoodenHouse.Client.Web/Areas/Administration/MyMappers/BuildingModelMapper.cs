using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.App_Start;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Models;
using Ninject;
using System.Collections.Generic;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class BuildingModelMapper : IGenericModelMapper<Building, BuildingCompleteVm>
    {
        private readonly ICategoryModelMapper categoryModelMapper;
        private readonly IGenericModelMapper<Product, ProductCompleteVm> productModelMapper;
        private readonly IGenericModelMapper<Material, MaterialCompleteVm> materialModelMapper;
        private readonly IGenericModelMapper<Picture, PictureCompleteVm> pictureModelMapper;

        public BuildingModelMapper()
        {
            // TODO fix Ninject binding
            //this.categoryModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Category, CategoryCompleteVm>>();
            this.categoryModelMapper = NinjectWebCommon.Kernel.Get<ICategoryModelMapper>();
            this.productModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Product, ProductCompleteVm>>();
            this.materialModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Material, MaterialCompleteVm>>();
            this.pictureModelMapper = NinjectWebCommon.Kernel.Get<IGenericModelMapper<Picture, PictureCompleteVm>>();

            //this.categoryModelMapper = new CategoryModelMapper();
            //this.productModelMapper = new ProductModelMapper();
            //this.materialModelMapper = new MaterialModelMapper();
            //this.pictureModelMapper = new PictureModelMapper();
        }

        // TODO not used, because can not auto bind services in Ninject
        public BuildingModelMapper(ICategoryModelMapper categoryModelMapper,
            IGenericModelMapper<Product, ProductCompleteVm> productModelMapper,
            IGenericModelMapper<Material, MaterialCompleteVm> materialModelMapper,
            IGenericModelMapper<Picture, PictureCompleteVm> pictureModelMapper)
        {
            // Todo insert validation
            this.categoryModelMapper = categoryModelMapper;
            this.productModelMapper = productModelMapper;
            this.materialModelMapper = materialModelMapper;
            this.pictureModelMapper = pictureModelMapper;
        }

        public BuildingCompleteVm Model2ViewModel(Building model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            var viewModelToReturn = new BuildingCompleteVm();
            
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

            viewModelToReturn.Materials = new List<MaterialCompleteVm>();
            viewModelToReturn.Pictures = new List<PictureCompleteVm>();

            // TODO Add better validation
            if (model.Materials != null)
            {
                if (model.Materials.Count > 0)
                {
                    foreach (var material in model.Materials)
                    {
                        var m = this.materialModelMapper.Model2ViewModel(material);
                        viewModelToReturn.Materials.Add(m);
                    }
                }
            }

            // TODO Add better validation
            if (model.Pictures != null)
            {
                if (model.Pictures.Count > 0)
                {
                    foreach (var picture in model.Pictures)
                    {
                        var p = this.pictureModelMapper.Model2ViewModel(picture);
                        viewModelToReturn.Pictures.Add(p);
                    }
                }
            }

            return viewModelToReturn;
        }

        public Building ViewModel2Model(BuildingCompleteVm viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

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

            // TODO Add better validation
            if (viewModel.Category != null)
            {
                var cat = this.categoryModelMapper.ViewModel2Model(viewModel.Category);
                modelToReturn.Category = null;
            }

            modelToReturn.ProductId = viewModel.ProductId;

            // TODO Add better validation
            if (viewModel.Product != null)
            {
                var prod = this.productModelMapper.ViewModel2Model(viewModel.Product);
                modelToReturn.Product = prod;
            }

            // TODO Add better validation
            if (viewModel.Materials != null)
            {
                if (viewModel.Materials.Count > 0)
                {
                    foreach(var material in viewModel.Materials)
                    {
                        var m = this.materialModelMapper.ViewModel2Model(material);
                        modelToReturn.Materials.Add(m); 
                    }
                }
            }

            // TODO Add better validation
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