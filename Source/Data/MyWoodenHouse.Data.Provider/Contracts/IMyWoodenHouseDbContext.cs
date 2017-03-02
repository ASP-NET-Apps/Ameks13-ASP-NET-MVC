using MyWoodenHouse.Data.Models;
using System.Data.Entity;

namespace MyWoodenHouse.Data.Provider.Contracts
{
    public interface IMyWoodenHouseDbContext
    {
        IDbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
