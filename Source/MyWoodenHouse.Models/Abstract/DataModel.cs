using System;
using MyWoodenHouse.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyWoodenHouse.Constants.Models;

namespace MyWoodenHouse.Models.Abstract
{
    public abstract class DataModel : IHasIntId, IAuditable, IDeletable
    {
        [Key]
        [Required]
        [Range(Consts.DataModel.Id.MinValue, Consts.DataModel.Id.MaxValue, ErrorMessage = Consts.DataModel.Id.ErrorMessage)]
        public int Id { get; set; }

        [Index]
        [Required]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [MaxLength(Consts.DataModel.CreatedBy.MaxLength, ErrorMessage = Consts.DataModel.CreatedBy.ErrorMessageMaxLength)]
        [MinLength(Consts.DataModel.CreatedBy.MinLength, ErrorMessage = Consts.DataModel.CreatedBy.ErrorMessageMinLength)]
        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [MaxLength(Consts.DataModel.ModifiedBy.MaxLength, ErrorMessage = Consts.DataModel.ModifiedBy.ErrorMessageMaxLength)]
        [MinLength(Consts.DataModel.ModifiedBy.MinLength, ErrorMessage = Consts.DataModel.ModifiedBy.ErrorMessageMinLength)]
        public string ModifiedBy { get; set; }
    }
}
