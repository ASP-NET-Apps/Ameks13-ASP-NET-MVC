using MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Contracts;
using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Products
{
    public class ProductCompleteViewModel : IProductCompleteViewModel
    {
        public ProductCompleteViewModel()
        {
        }

        public ProductCompleteViewModel(IProduct product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Description = product.Description;
        }

        [Display(Name = "Id")]
        [Range(Consts.Product.Id.MinValue, Consts.Product.Id.MaxValue, ErrorMessage = Consts.Product.Id.ErrorMessage)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(Consts.Product.Name.MaxLength, ErrorMessage = Consts.Product.Name.ErrorMessageMaxLength)]
        [MinLength(Consts.Product.Name.MinLength, ErrorMessage = Consts.Product.Name.ErrorMessageMinLength)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(Consts.Product.Description.MaxLength, ErrorMessage = Consts.Product.Description.ErrorMessageMaxLength)]
        public string Description { get; set; }

        [Display(Name = "Product")]
        public string ModelName { get; set; }
    }
}