
using System;
using System.Linq;
using System.Linq.Expressions;
using Weather.Domain.Enum;
using Weather.Domain.NotMapped;

namespace Weather.Domain.Interfaces
{
    public interface IManager<T> where T : class
    {
        IQueryable<T> GetBy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T FindBy(Expression<Func<T, bool>> predicate, string includeProperties = "");
        T FindBy(object id);
        DomainResult<T> Insert(T entity);
        DomainResult<T> Add(T entity);
        DomainResult<T> Delete(object id);
        DomainResult<T> Delete(T entity);
        DomainResult<T> Update(T entity);

        bool IsValid(T entity, ERepositoryOperacao operacao);

        bool InsertIsValid(T entity);
        bool UpdateIsValid(T entity);
        bool DeleteIsValid(T entity);

        DomainResult<T> GetDomainResult();
    }
}
