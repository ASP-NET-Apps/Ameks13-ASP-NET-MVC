using MyWoodenHouse.Ef.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyWoodenHouse.Data.Provider.Contracts
{
    public interface IMyWoodenHouseDbContext : IDisposable
    {
        IDbSet<Category> Categories { get; set; }

        EntityState GetEntityState(object entity);

        void SetEntityState(object entity, EntityState state);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
