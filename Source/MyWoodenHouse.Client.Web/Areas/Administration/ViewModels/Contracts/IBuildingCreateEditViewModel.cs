using System.Collections.Generic;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IBuildingCreateEditViewModel
    {
        IBuildingCompleteViewModel BuildingCompleteViewModel { get; set; }

        SelectList CategoryList { get; set; }

        SelectList ProductList { get; set; }

        string ModelName { get; set; }
    }
}
