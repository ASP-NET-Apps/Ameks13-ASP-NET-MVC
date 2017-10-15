using System;
using MyWoodenHouse.Ef.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Contracts.Models;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
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
            modelToReturn.Name = viewModel.Name;
            modelToReturn.Width = viewModel.Width;
            modelToReturn.Height = viewModel.Height;
            modelToReturn.FileContent = viewModel.FileContent;
            modelToReturn.Url = viewModel.Url;
            modelToReturn.GetFrom = (int)viewModel.GetFrom;

            return modelToReturn;
        }
    }
}