using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.ViewModels.Contracts
{
    public interface ICategoryViewModel
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
