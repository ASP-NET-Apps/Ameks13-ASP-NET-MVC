﻿using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Ef.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.MetaData
{
    public class PriceMetaData : IPriceEf
    {
        [Key]
        [Range(Consts.Price.Id.MinValue, Consts.Price.Id.MaxValue, ErrorMessage = Consts.Price.Id.ErrorMessage)]
        public int Id { get; set; }

        [Range(Consts.Price.Value.MinValue, Consts.Price.Value.MaxValue, ErrorMessage = Consts.Price.Value.ErrorMessage)]
        public float? Value { get; set; }

        [Required]
        [Display(Name = "Currency")]
        [MaxLength(Consts.Price.Currency.MaxLength, ErrorMessage = Consts.Price.Currency.ErrorMessageMaxLength)]
        [MinLength(Consts.Price.Currency.MinLength, ErrorMessage = Consts.Price.Currency.ErrorMessageMinLength)]
        public string Currency { get; set; }

        [Display(Name = "Per Square Meter")]
        [Range(Consts.Price.PerSquareMeter.MinValue, Consts.Price.PerSquareMeter.MaxValue, ErrorMessage = Consts.Price.PerSquareMeter.ErrorMessage)]
        public float PerSquareMeter { get; set; }

        [Required]
        [Display(Name = "PriceCategoryId")]
        [Range(Consts.Price.PriceCategoryId.MinValue, Consts.Price.PriceCategoryId.MaxValue, ErrorMessage = Consts.Price.PriceCategoryId.ErrorMessage)]
        public int PriceCategoryId { get; set; }

        [ForeignKey("PriceCategoryId")]
        public PriceCategory PriceCategory { get; set; }

        [ForeignKey("Id")]
        public ICollection<Product> Products { get; set; }

        
    }
}
