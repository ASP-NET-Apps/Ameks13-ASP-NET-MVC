using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models.Constants.Models
{
    public partial class Consts
    {
        //[Key]
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ErrorResources))]
        //[Display(Order = 0, Name = "UserNameLabel", ResourceType = typeof(RegistrationDataResources))]
        //[RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessageResourceName = "ValidationErrorInvalidUserName", ErrorMessageResourceType = typeof(ErrorResources))]
        //[StringLength(255, MinimumLength = 4, ErrorMessageResourceName = "ValidationErrorBadUserNameLength", ErrorMessageResourceType = typeof(ErrorResources))]
        //public string UserName { get; set; }

        public struct Constuctor
        {
            public struct ErrorMessage
            {
                public static string AnInstanceOfObjectIsRequiredToConstructClass = "An instance of {0} is required to use this {1}";
            }
        };
    }
}
