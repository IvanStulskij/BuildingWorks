using System;
using System.Linq;
using System.Linq.Expressions;

namespace BuildingWorks.Models.Bases
{
    public interface IBaseTable<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
