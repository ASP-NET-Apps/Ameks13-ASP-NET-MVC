using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Constants.Models
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
                public static string DbContextDoesNotContainDbSet = "DbContext does not contain DbSet<{0}>";
            }
        };

        public struct GeneralData
        {
            public struct ErrorMessage
            {
                public static string NoEntryFoundWithTheProvidedId = "No entry found with the provided Id = {0}";
            }
        };

        public struct SelectData
        {
            public struct ErrorMessage
            {
                public static string SelectByIdIsPossibleOnlyWithNotNullableParameter = "Select by Id is only possible with not nullable id parameter";
                public static string SelectByIdIsPossibleOnlyWithPositiveParameter = "Select by Id is only possible positive Id parameter. Id = {0}";
                public static string NoItemFoundByTheGivenId = "No {0} found by the given Id = {1}";

            }
        };

        public struct DeleteData
        {
            public struct ErrorMessage
            {
                public static string DeleteByIdIsPossibleOnlyWithNotNullableParameter = "Delete by Id is only possible with not nullable id parameter";
                public static string DeleteByIdIsPossibleOnlyWithPositiveParameter = "Delete by Id is only possible positive Id parameter. Id = {0}";
                public static string NoItemDeletedByTheGivenId = "Can not delete {0}. No {0} found by the given Id = {1}";

            }
        };
    }
}
