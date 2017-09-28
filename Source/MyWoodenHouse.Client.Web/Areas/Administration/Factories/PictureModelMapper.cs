using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Client.Web.Areas.Administration.Factories.Contracts;

namespace MyWoodenHouse.Client.Web.Areas.Administration.Factories
{
    public class PictureModelMapper : IGenericModelMapper<Picture, PictureCompleteViewModel>
    {
        public PictureCompleteViewModel Model2ViewModel(Picture model)
        {
            if (model == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var viewModelToReturn = new PictureCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Picture ViewModel2Model(PictureCompleteViewModel viewModel)
        {
            if (viewModel == null)
            {
                // TODO prepare message
                throw new ArgumentNullException();
            }

            var modelToReturn = new Picture();
            modelToReturn.Id = viewModel.Id;
            modelToReturn.Width = viewModel.Width;
            modelToReturn.Height = viewModel.Height;
            modelToReturn.PictureContent = viewModel.PictureContent;
            modelToReturn.PictureUrl = viewModel.PictureUrl;

            return modelToReturn;
        }
    }
}