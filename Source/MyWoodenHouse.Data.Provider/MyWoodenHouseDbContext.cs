using Microsoft.AspNet.Identity.EntityFramework;
using MyWoodenHouse.Models;
using MyWoodenHouse.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyWoodenHouse.Data.Provider
{
    public class MyWoodenHouseDbContext : IdentityDbContext<User>
    {
        private const string CategoriesT = "Categories";
        private const string MaterialsT = "Materials";
        private const string PicturesT = "Pictures";
        private const string PriceCategoriesT = "PriceCategories";
        private const string PricesT = "Prices";
        private const string ProductsT = "Products";
        private const string PagesT = "Pages";
        private const string BuildingsT = "Buildings";
        private const string MaterialBuildingsT = "MaterialBuildings";
        private const string PictureBuildingsT = "PictureBuildings";

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
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Material> Materials { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public IDbSet<PriceCategory> PriceCategories { get; set; }

        public IDbSet<Price> Prices { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Page> Pages { get; set; }

        public IDbSet<Building> Buildings { get; set; }

        public IDbSet<MaterialBuilding> MaterialBuildings { get; set; }
                
        public static MyWoodenHouseDbContext Create()
        {
            return new MyWoodenHouseDbContext();
        }

        public virtual EntityState GetEntityState(object entity)
        {
            EntityState stateToReturn = Entry(entity).State;

            return stateToReturn;
        }

        public virtual void SetEntityState(object entity, EntityState state)
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
            modelBuilder.Entity<Building>().ToTable(BuildingsT);

            //Categories
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Category>().ToTable(CategoriesT);

            //Materials
            modelBuilder.Entity<Material>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Material>().ToTable(MaterialsT);

            //Pictures
            modelBuilder.Entity<Picture>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Picture>().ToTable(PicturesT);

            //Prices
            modelBuilder.Entity<Price>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Price>().ToTable(PricesT);

            //PriceCategories
            modelBuilder.Entity<PriceCategory>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<PriceCategory>().ToTable(PriceCategoriesT);

            //Products
            modelBuilder.Entity<Product>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Product>().ToTable(ProductsT);

            //Pages
            modelBuilder.Entity<Page>()
                .HasKey(c => c.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Page>().ToTable(PagesT);

            // ***************** Many to many configurations *******************
            modelBuilder.Entity<MaterialBuilding>()
                .HasKey(i => new { i.BuildingId, i.MaterialId })
                .Map(m => m.ToTable(MaterialBuildingsT));

            modelBuilder.Entity<Building>()
                .HasMany(buildingsT => buildingsT.Materials)
                .WithMany(materialsT => materialsT.Buildings)
                .Map(m =>
                {
                    m.MapLeftKey("BuildingId");
                    m.MapRightKey("MaterialId");
                    //m.ToTable(MaterialBuildingsT);
                });

            modelBuilder.Entity<PictureBuilding>()
              .HasKey(table => new { table.BuildingId, table.PictureId })
              .Map(m => m.ToTable(PictureBuildingsT));

            modelBuilder.Entity<Building>()
                .HasMany(buildingsT => buildingsT.Pictures)
                .WithMany(picturesT => picturesT.Buildings)
                .Map(m =>
                {
                    m.MapLeftKey("BuildingId");
                    m.MapRightKey("PictureId");
                });

            // TODO use this commented lines later to resolve many-to-many update delete issue
            //    modelBuilder.Entity<MaterialBuilding>()
            //        .HasRequired(mbT => mbT.Building)
            //        .WithMany()
            //        .HasForeignKey(i => i.BuildingId)
            //        .WillCascadeOnDelete(false); //the one

            //    modelBuilder.Entity<MaterialBuilding>()
            //        .HasRequired(mbT => mbT.Material)
            //        .WithMany()
            //        .HasForeignKey(i => i.MaterialId)
            //        .WillCascadeOnDelete(false); //the one

            base.OnModelCreating(modelBuilder);
        }
    }
}
