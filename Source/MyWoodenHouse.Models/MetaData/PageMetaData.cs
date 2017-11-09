using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Abstract;
using MyWoodenHouse.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Models.MetaData
{
    public class PageMetaData : DataModel, IPage
    {
        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Page.Name.MaxLength, ErrorMessage = Consts.Page.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Page.Name.MinLength, ErrorMessage = Consts.Page.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Material.Name.MaxLength, ErrorMessage = Consts.Material.Name.ErrorMessageMaxLength)]
        public string Description { get; set; }

        [Display(Name = "Content")]
        public string HtmlContent { get; set; }

        [Required]
        [Display(Name = "Language")]
        [MaxLength(Consts.Page.LanguageCultureName.MaxLength, ErrorMessage = Consts.Page.LanguageCultureName.ErrorMessageMaxLength)]
        [MinLength(Consts.Page.LanguageCultureName.MinLength, ErrorMessage = Consts.Page.LanguageCultureName.ErrorMessageMinLength)]
        public string LanguageCultureName { get; set; }

    }
}
