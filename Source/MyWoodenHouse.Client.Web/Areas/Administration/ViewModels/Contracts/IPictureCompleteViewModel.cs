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
        
        string Name { get; set; }

        Nullable<int> Width { get; set; }

        Nullable<int> Height { get; set; }

        byte[] FileContent { get; set; }

        string Url { get; set; }

        int GetFrom { get; set; }
    }
}
