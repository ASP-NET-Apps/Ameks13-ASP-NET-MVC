using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IPriceCompleteVm
    {
        int Id { get; set; }

        Nullable<float> Value { get; set; }

        string Currency { get; set; }

        float PerSquareMeter { get; set; }

        int PriceCategoryId { get; set; }
    }
}
