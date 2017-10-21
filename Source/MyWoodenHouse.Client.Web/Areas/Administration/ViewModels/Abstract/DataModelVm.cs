using MyWoodenHouse.Constants.Models;
using MyWoodenHouse.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWoodenHouse.Client.Web.Areas.Administration.ViewModels.Abstract
{
    public abstract class DataModelVm : IAuditable, IDeletable
    {
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