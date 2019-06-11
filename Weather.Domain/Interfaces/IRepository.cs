using System;
using System.Linq;
using System.Linq.Expressions;

namespace Weather.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetBy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T FindBy(Expression<Func<T, bool>> predicate, string includeProperties = "");
        T FindBy(object id);
        void Add(T entity);
        T Insert(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Update(T entity);
    }
}
