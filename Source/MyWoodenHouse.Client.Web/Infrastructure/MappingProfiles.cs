using AutoMapper;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Buildings;
using MyWoodenHouse.Client.Web.ViewModels.Gallery;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Building, BuildingCompleteVm>().ReverseMap();
            CreateMap<Category, CategoryCompleteVm>().ReverseMap();
            CreateMap<Material, MaterialCompleteVm>().ReverseMap();
            CreateMap<Picture, PictureCompleteVm>().ReverseMap();
            CreateMap<Price, PriceCompleteVm>().ReverseMap();
            CreateMap<Product, ProductCompleteVm>().ReverseMap();
            CreateMap<Page, PageCompleteVm>().ReverseMap();

            CreateMap<Picture, PictureGalleryVm>().ReverseMap();

        }
    }
}