using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts
{
    //public interface ICategoryModelMapper : IGenericModelMapper<Category, CategoryCompleteViewModel>
    public interface ICategoryModelMapper
    {
        CategoryCompleteViewModel Model2ViewModel(Category model);

        Category ViewModel2Model(CategoryCompleteViewModel viewModel);
    }
}
