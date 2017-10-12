using MyWoodenHouse.Data.Provider.Contracts;
using MyWoodenHouse.Ef.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System;
using MyWoodenHouse.Contracts.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyWoodenHouse.Data.Provider
{
    public class MyWoodenHouseDbContext : DbContext, IMyWoodenHouseDbContext
    {
        // Your context has been configured to use a 'MyWoodenHouseDbContextConnectionString'. 
        // All connection strings are extracted in separate ConnectionStrings.config file and 
        // linked to your main application's configuration file (App.config or Web.config).
        // By default, this connection string targets the 
        // 'MyWoodenHouse' database on your MSSQL server and uses specific credentials for granting access. 
        // 
        // If you wish to connect to different database you have to use a different connection string 
        // from your (App.config or Web.config) file. 
        //
        // Uncomment following lines if you want explicitly to use (LocalDb)
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

        public virtual IDbSet<Material> Materials { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public IDbSet<PriceCategory> PriceCategories { get; set; }

        public IDbSet<Price> Prices { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Building> Buildings { get; set; }

        public IDbSet<BuildingMaterial> BuildingMaterials { get; set; }


        //public DbSet<PriceOffer> PriceOffers { get; set; }

        //public EfCoreContext(
        //    DbContextOptions<EfCoreContext> options)      
        //: base(options) { }

        //protected override void
        //    OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookAuthor>()
        //        .HasKey(x => new { x.BookId, x.AuthorId });



        public EntityState GetEntityState(object entity)
        {
            EntityState stateToReturn = Entry(entity).State;

            return stateToReturn;
        }

        public void SetEntityState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Entity Framework CTP 4. “Cannot insert the value NULL into column” -Even though there is no NULL value
            //http://stackoverflow.com/questions/4444407/entity-framework-ctp-4-cannot-insert-the-value-null-into-column-even-though/5338384#5338384
            //Have you tried explicitly specifying the StoreGeneratedPattern?
            // modelBuilder.Entity<BOB>().HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGenerationOption(DatabaseGenerationOption.None); 
            // modelBuilder.Entity<BOB>().ToTable("BOB");

            //Building
            modelBuilder.Entity<Building>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Building>().ToTable("Buildings");

            //Categories
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Category>().ToTable("Categories");

            //Materials
            modelBuilder.Entity<Material>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Material>().ToTable("Materials");

            //Pictures
            modelBuilder.Entity<Picture>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Picture>().ToTable("Pictures");

            //Prices
            modelBuilder.Entity<Price>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Price>().ToTable("Prices");

            //PriceCategories
            modelBuilder.Entity<PriceCategory>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<PriceCategory>().ToTable("PriceCategories");

            //Products
            modelBuilder.Entity<Product>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Product>().ToTable("Products");

            //BuildingsMaterials
            modelBuilder.Entity<BuildingMaterial>()
                .HasKey(x => new { x.BuildingId, x.MaterialId });
            // modelBuilder.Entity<BuildingMaterial>().ToTable("BuildingsMaterials");

            modelBuilder.Entity<Building>()
                .HasMany(t => t.Materials)
                .WithMany(t => t.Buildings)
                .Map(m =>
                {                    
                    m.MapLeftKey("MaterialId");
                    m.MapRightKey("BuildingId");
                    m.ToTable("BuildingsMaterials");
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}
