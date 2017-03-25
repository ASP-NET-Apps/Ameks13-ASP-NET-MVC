using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Data.Provider.Contracts
{
    public interface IEfCrudOperatons<T> where T : class
    {
        T SelectById(int? id);

        IQueryable<T> All { get; }

        IEnumerable<T> Select();

        IEnumerable<T> Select(Expression<Func<T, bool>> filterExpression);

        int Insert(T entity);

        int Update(T entity);

        void Delete(T entity);

        void Delete(int? id);
    }
}
