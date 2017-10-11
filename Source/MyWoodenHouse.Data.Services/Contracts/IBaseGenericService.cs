using System.Collections.Generic;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface IBaseGenericService<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int? id);

        int Insert(T entity);

        T Update(T entity);

        void Delete(int? id);

        void Delete(T entity);
    }
}
