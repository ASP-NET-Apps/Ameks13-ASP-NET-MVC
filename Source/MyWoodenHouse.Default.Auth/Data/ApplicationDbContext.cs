using Microsoft.AspNet.Identity.EntityFramework;
using MyWoodenHouse.Default.Auth.Models;

namespace MyWoodenHouse.Default.Auth.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=MyWoodenHouseDbContextConnectionString", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
