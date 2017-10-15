using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Materials;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IBuildingCompleteViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        Nullable<float> UsableArea { get; set; }

        Nullable<float> BuiltUpArea { get; set; }

        Nullable<int> FloorsCount { get; set; }

        Nullable<int> RoomsCount { get; set; }

        Nullable<int> BathroomsCount { get; set; }
        
        int CategoryId { get; set; }

        CategoryCompleteViewModel Category { get; set; }

        int ProductId { get; set; }

        ProductCompleteViewModel Product { get; set; }

        ICollection<MaterialCompleteViewModel> Materials { get; set; }

        ICollection<PictureCompleteViewModel> Pictures { get; set; }
    }
}
