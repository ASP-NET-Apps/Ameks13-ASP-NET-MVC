using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.ViewModels.Contracts
{
    public interface ICategoryMainViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string ModelName { get; set; }
    }
}
