using System;
using MyWoodenHouse.Pure.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Categories;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class CategoryModelMapper : IGenericModelMapper<ICategory, ICategoryCompleteViewModel>
    {

        public ICategoryCompleteViewModel Model2ViewModel(ICategory model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new CategoryCompleteViewModel(model);

            return modelToReturn;
        }

        public ICategory ViewModel2Model(ICategoryCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new CategoryModel();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Name = viewModel.Name;

            return modelToReturn;
        }
    }
}