using MyWoodenHouse.Data.Provider.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyWoodenHouse.Data.Provider.Contracts
{
    public interface IEfCrudOperatons<T> where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        T SelectById(int? id);

        IEnumerable<T> SelectAll();

        IEnumerable<T> SelectAll(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> SelectAll<T1>(Expression<Func<T, bool>> filterExpression,
                                Expression<Func<T, T1>> sortExpression,
                                SortOrder? sortOrder);

        IEnumerable<T2> SelectAll<T1, T2>(Expression<Func<T, bool>> filterExpression,
                                Expression<Func<T, T1>> sortExpression,
                                SortOrder? sortOrder,
                                Expression<Func<T, T2>> selectExpression);

        int Insert(T entity);

        int Update(T entity);

        void Delete(T entity);

        void Delete(int? id);

        void DeletePermanent(T entity);
    }
}
