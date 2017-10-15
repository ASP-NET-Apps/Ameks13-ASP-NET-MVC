using MyWoodenHouse.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Ef.Models.Models
{
    public abstract class DataModel : IAuditable, IDeletable
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
