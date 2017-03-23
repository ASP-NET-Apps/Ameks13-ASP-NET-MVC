using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models.Contracts
{
    public interface IHasIntId
    {
        int Id { get; set; }
    }
}
