using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts
{
    public interface IMaterialCompleteViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string ModelName { get; set; }
    }
}
