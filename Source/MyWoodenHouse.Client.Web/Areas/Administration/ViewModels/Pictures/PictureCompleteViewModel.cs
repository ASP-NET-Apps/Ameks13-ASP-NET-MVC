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
            this.Name = picture.Name;
            this.Width = picture.Width;
            this.Height = picture.Height;
            this.FileContent = picture.FileContent;
            this.Url = picture.Url;
            this.GetFrom = picture.GetFrom;
        }

        [Display(Name = "Id")]
        [Range(Consts.Picture.Id.MinValue, Consts.Picture.Id.MaxValue, ErrorMessage = Consts.Picture.Id.ErrorMessage)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(Consts.Picture.Name.MaxLength, ErrorMessage = Consts.Picture.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.Name.MinLength, ErrorMessage = Consts.Picture.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Width")]
        [Range(Consts.Picture.Width.MinValue, Consts.Picture.Width.MaxValue, ErrorMessage = Consts.Picture.Width.ErrorMessage)]
        public int? Width { get; set; }

        [Display(Name = "Height")]
        [Range(Consts.Picture.Height.MinValue, Consts.Picture.Height.MaxValue, ErrorMessage = Consts.Picture.Height.ErrorMessage)]
        public int? Height { get; set; }

        [Display(Name = "File Content")]
        public byte[] FileContent { get; set; }

        [Required]
        [Display(Name = "Url")]
        [MaxLength(Consts.Picture.Url.MaxLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.Url.MinLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMinLength)]
        public string Url { get; set; }
        
        [Range(Consts.Picture.GetFrom.MinValue-1, Consts.Picture.GetFrom.MaxValue, ErrorMessage = Consts.Picture.GetFrom.ErrorMessage)]
        public int GetFrom { get; set; }

        [Display(Name = "Picture")]
        public string ModelName { get; set; }
    }
}