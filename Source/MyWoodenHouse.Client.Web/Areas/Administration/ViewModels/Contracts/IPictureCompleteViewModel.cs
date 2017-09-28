using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IPictureCompleteViewModel
    {
       int Id { get; set; }

       Nullable<int> Width { get; set; }

       Nullable<int> Height { get; set; }

       byte[] PictureContent { get; set; }

       string PictureUrl { get; set; }
    }
}
