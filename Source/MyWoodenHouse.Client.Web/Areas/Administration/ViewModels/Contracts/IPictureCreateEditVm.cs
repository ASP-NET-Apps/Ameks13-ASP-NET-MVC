using System.Collections.Generic;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IPictureCreateEditVm
    {
        PictureCompleteVm PictureCompleteVm { get; set; }

        int SelectedUploadSource { get; set; }

        SelectList UploadSourcesList { get; set; }

        string ModelName { get; set; }
    }
}