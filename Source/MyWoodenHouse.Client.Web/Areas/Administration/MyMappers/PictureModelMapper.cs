using Bytes2you.Validation;
using MyWoodenHouse.Client.Web.Areas.Administration.MyMappers.Contracts;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Client.Web.Areas.Administration.MyMappers
{
    public class PictureModelMapper : IGenericModelMapper<Picture, PictureCompleteViewModel>
    {
        public PictureModelMapper()
        {
        }

        public PictureCompleteViewModel Model2ViewModel(Picture model)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            // TODO use no parameter constructor and map properties here
            var viewModelToReturn = new PictureCompleteViewModel(model);

            return viewModelToReturn;
        }

        public Picture ViewModel2Model(PictureCompleteViewModel viewModel)
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