using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SaveMyURL.Model;

namespace SaveMyURL.Repositories
{
    public interface IEntityRepository<T> : IBaseRepository where T : Entity, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(long key);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Delete(long entityId);
    }
}
