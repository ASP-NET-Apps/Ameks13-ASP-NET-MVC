using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Data.Services.Enums;
using MyWoodenHouse.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class PictureModelMapper : IGenericModelMapper<Picture, PictureCompleteVm>
    {
        public PictureModelMapper()
        {
        }

        public PictureCompleteVm Model2ViewModel(Picture model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            var viewModelToReturn = new PictureCompleteVm();
            viewModelToReturn.Id = model.Id;
            viewModelToReturn.Name = model.Name;
            viewModelToReturn.Width = model.Width;
            viewModelToReturn.Height = model.Height;
            viewModelToReturn.FileContent = model.FileContent;
            viewModelToReturn.Url = model.Url;
            viewModelToReturn.GetFrom = (GetPictureContentFrom)model.GetFrom;

            return viewModelToReturn;
        }

        public Picture ViewModel2Model(PictureCompleteVm viewModel)
        {
            Guard.WhenArgument(viewModel, nameof(viewModel)).IsNull().Throw();

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