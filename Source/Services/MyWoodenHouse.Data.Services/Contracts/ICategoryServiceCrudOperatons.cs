using MyWoodenHouse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyWoodenHouse.Data.Services.Contracts
{
    public interface ICategoryServiceCrudOperatons
    {
        Category SelectById(int id);

        IEnumerable<Category> Select();

        IEnumerable<Category> Select(Expression<Func<Category, bool>> filterExpression);

        void Insert(Category category);

        void Update(Category category);

        void Delete(Category category);

        void Delete(int id);

        void SaveChanges();
    }
}
