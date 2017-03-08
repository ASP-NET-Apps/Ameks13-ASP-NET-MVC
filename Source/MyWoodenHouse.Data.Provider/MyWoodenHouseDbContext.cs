using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider
{
    public class MyWoodenHouseDbContext : DbContext, IMyWoodenHouseDbContext
    {
        // Your context has been configured to use a 'MyWoodenHouseDbContextConnectionString'. 
        // All connection strings are extracted in separate ConnectionStrings.config file and 
        // linked to your main application's configuration file (App.config or Web.config).
        // By default, this connection string targets the 
        // 'MyWoodenHouse' database on your MSSQL server and uses specific credetials for granting access. 
        // 
        // If you wish to connect to different database you have to use a different connection string 
        // from your (App.config or Web.config) file. 
        //
        // Uncomment folowing lines if you want explicitly to use (LocalDb)
        //public MyWoodenHouseDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}
        public MyWoodenHouseDbContext() 
            : base("name=MyWoodenHouseDbContextConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Entity Framework CTP 4. “Cannot insert the value NULL into column” -Even though there is no NULL value
            //http://stackoverflow.com/questions/4444407/entity-framework-ctp-4-cannot-insert-the-value-null-into-column-even-though/5338384#5338384
            //Have you tried explicitly specifying the StoreGeneratedPattern?
            // modelBuilder.Entity<BOB>().HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGenerationOption(DatabaseGenerationOption.None); 
            // modelBuilder.Entity<BOB>().ToTable("BOB");
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Category>().ToTable("Categories");

            base.OnModelCreating(modelBuilder);
        }
    }
}
