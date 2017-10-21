using System;
using System.Collections.Generic;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IBuildingCompleteVm
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

        CategoryCompleteVm Category { get; set; }

        int ProductId { get; set; }

        ProductCompleteVm Product { get; set; }

        ICollection<MaterialCompleteVm> Materials { get; set; }

        ICollection<PictureCompleteVm> Pictures { get; set; }
    }
}
