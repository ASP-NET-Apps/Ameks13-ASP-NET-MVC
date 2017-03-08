using MyWoodenHouse.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyWoodenHouse.Data.Provider.Contracts
{
    public interface IMyWoodenHouseDbContext : IDisposable
    {
        IDbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
