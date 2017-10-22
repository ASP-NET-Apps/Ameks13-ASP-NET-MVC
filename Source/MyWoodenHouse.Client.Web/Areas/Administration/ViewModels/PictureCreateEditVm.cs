using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System;
using MyWoodenHouse.Models;
using System.Collections.Generic;
using Bytes2you.Validation;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels
{
    public class PictureCreateEditVm : IPictureCreateEditVm
    {
        private PictureCompleteVm pictureCompleteVm;

        public PictureCreateEditVm()
        {
        }

        public PictureCreateEditVm(PictureCompleteVm pictureCompleteVm)
        {
            Guard.WhenArgument(pictureCompleteVm, nameof(pictureCompleteVm)).IsNull().Throw();

            this.PictureCompleteVm = pictureCompleteVm;
        }
         
        public PictureCompleteVm PictureCompleteVm
        {
            get
            {
                return this.pictureCompleteVm;
            }
            set
            {
                this.pictureCompleteVm = value;
            }
        }

        [Display(Name = "Upload Sources")]
        public SelectList UploadSourcesList { get; set; }

        public int SelectedUploadSource { get; set; }

        [Display(Name = "Picture")]
        public string ModelName { get; set; }
    }
}