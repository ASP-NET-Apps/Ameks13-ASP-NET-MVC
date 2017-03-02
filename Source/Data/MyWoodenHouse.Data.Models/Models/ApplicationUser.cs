using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        // TODO uncomment after extractin Identity in a separate project
        //public virtual ClaimsIdentity GenerateUserIdentkity(IApplicationUserManager manager)
        public virtual ClaimsIdentity GenerateUserIdentity(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        // TODO uncomment after extractin Identity in a separate project
        //public virtual Task<ClaimsIdentity> GenerateUserIdentityAsync(IApplicationUserManager manager)
        public virtual Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            return Task.FromResult(this.GenerateUserIdentity(manager));
        }
    }
}
