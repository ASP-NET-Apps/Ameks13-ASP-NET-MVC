using System.Web.Mvc;

namespace MyWoodenHouse.Client.Web.CustomAttributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) 
            : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}