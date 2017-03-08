﻿using MyWoodenHouse.Data.Models.Constants.Models;
using MyWoodenHouse.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models.MetaData
{
    public class PictureMetaData : IPicture
    {
        [Key]
        public int Id { get; set; }

        [Range(Consts.Picture.Width.MinValue, Consts.Picture.Width.MaxValue, ErrorMessage = Consts.Picture.Width.ErrorMessage)]
        public int? Width { get; set; }

        [Range(Consts.Picture.Height.MinValue, Consts.Picture.Height.MaxValue, ErrorMessage = Consts.Picture.Height.ErrorMessage)]
        public int? Height { get; set; }

        public byte[] PictureContent { get; set; }

        [MaxLength(Consts.Picture.PictureUrl.MaxLength, ErrorMessage = Consts.Picture.PictureUrl.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.PictureUrl.MinLength, ErrorMessage = Consts.Picture.PictureUrl.ErrorMessageMinLength)]
        public string PictureUrl { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}
