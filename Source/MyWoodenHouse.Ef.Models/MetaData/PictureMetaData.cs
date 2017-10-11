using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyWoodenHouse.Contracts.Models;
using System;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class PictureMetaData : IPictureEf
    {
        [Key]
        [Range(Consts.Picture.Id.MinValue, Consts.Picture.Id.MaxValue, ErrorMessage = Consts.Picture.Id.ErrorMessage)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(Consts.Picture.Name.MaxLength, ErrorMessage = Consts.Picture.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.Name.MinLength, ErrorMessage = Consts.Picture.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Range(Consts.Picture.Width.MinValue, Consts.Picture.Width.MaxValue, ErrorMessage = Consts.Picture.Width.ErrorMessage)]
        public int? Width { get; set; }

        [Range(Consts.Picture.Height.MinValue, Consts.Picture.Height.MaxValue, ErrorMessage = Consts.Picture.Height.ErrorMessage)]
        public int? Height { get; set; }

        public byte[] FileContent { get; set; }

        [MaxLength(Consts.Picture.Url.MaxLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMaxLength)]
        [MinLength(Consts.Picture.Url.MinLength, ErrorMessage = Consts.Picture.Url.ErrorMessageMinLength)]
        public string Url { get; set; }

        [Required]
        [Range(Consts.Picture.GetFrom.MinValue, Consts.Picture.GetFrom.MaxValue, ErrorMessage = Consts.Picture.GetFrom.ErrorMessage)]
        public int GetFrom { get; set; }

        public ICollection<Building> Buildings { get; set; }      
    }
}
