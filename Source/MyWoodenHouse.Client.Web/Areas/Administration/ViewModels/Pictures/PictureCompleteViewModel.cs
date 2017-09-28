using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Pictures
{
    public class PictureCompleteViewModel : IPictureCompleteViewModel
    {
        public PictureCompleteViewModel()
        {
        }

        public PictureCompleteViewModel(IPicture picture)
        {
            this.Id = picture.Id;
            this.Width = picture.Width;
            this.Height = picture.Height;
            this.PictureContent = picture.PictureContent;
            this.PictureUrl = picture.PictureUrl;
        }

        [Display(Name = "Id")]
        [Range(Consts.Picture.Id.MinValue, Consts.Picture.Id.MaxValue, ErrorMessage = Consts.Picture.Id.ErrorMessage)]
        public int Id { get; set; }

        [Display(Name = "Width")]
        [Range(Consts.Picture.Width.MinValue, Consts.Picture.Width.MaxValue, ErrorMessage = Consts.Picture.Width.ErrorMessage)]
        public int? Width { get; set; }

        [Display(Name = "Height")]
        [Range(Consts.Picture.Height.MinValue, Consts.Picture.Height.MaxValue, ErrorMessage = Consts.Picture.Height.ErrorMessage)]
        public int? Height { get; set; }

        [Display(Name = "Picture Content")]

        public byte[] PictureContent { get; set; }

        [Display(Name = "Picture Url")]
        [MaxLength(Consts.Picture.PictureUrl.MaxLength, ErrorMessage = Consts.Picture.PictureUrl.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.PictureUrl.MinLength, ErrorMessage = Consts.Picture.PictureUrl.ErrorMessageMinLength)]
        public string PictureUrl { get; set; }
    }
}