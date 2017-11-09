using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Abstract;
using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Data.Services.Enums;
using System.ComponentModel.DataAnnotations;
using System;
using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels
{
    public class PageCompleteVm : DataModelVm, IPageCompleteVm
    {
        public PageCompleteVm()
        {
        }

        [Display(Name = "Id")]
        [Range(Consts.Page.Id.MinValue, Consts.Page.Id.MaxValue, ErrorMessage = Consts.Page.Id.ErrorMessage)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(Consts.Page.Name.MaxLength, ErrorMessage = Consts.Page.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Page.Name.MinLength, ErrorMessage = Consts.Page.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Page.Description.MaxLength, ErrorMessage = Consts.Page.Description.ErrorMessageMaxLength)]
        public string Description { get; set; }

        [AllowHtml]
        [Display(Name = "Content")]        
        public string HtmlContent { get; set; }

        [Display(Name = "Language")]
        public string LanguageCultureName { get; set; }

        [Display(Name = "Page")]
        public string ModelName { get; set; }

    }
}