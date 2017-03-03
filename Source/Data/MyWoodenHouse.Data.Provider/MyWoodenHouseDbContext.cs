﻿using Microsoft.AspNet.Identity.EntityFramework;
using MyWoodenHouse.Data.Models;
using MyWoodenHouse.Data.Models.Models;
using MyWoodenHouse.Data.Provider.Contracts;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider
{
    public class MyWoodenHouseDbContext : IdentityDbContext<ApplicationUser>, IMyWoodenHouseDbContext
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
    }
}