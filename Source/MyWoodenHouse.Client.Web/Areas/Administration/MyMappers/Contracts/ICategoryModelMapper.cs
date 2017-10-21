using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels;
using MyWoodenHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts
{
    //public interface ICategoryModelMapper : IGenericModelMapper<Category, CategoryCompleteVm>
    public interface ICategoryModelMapper
    {
        CategoryCompleteVm Model2ViewModel(Category model);

        Category ViewModel2Model(CategoryCompleteVm viewModel);
    }
}
