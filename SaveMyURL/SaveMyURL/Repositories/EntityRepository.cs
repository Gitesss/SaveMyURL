using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using SaveMyURL.Model;

namespace SaveMyURL.Repositories
{
    public abstract class EntityRepository<T> : BaseRepository, IEntityRepository<T>
           where T : Entity, new()
    {
        protected EntityRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public virtual IQueryable<T> GetAll()
        {
            return ApplicationContext.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return GetAll();
        }

        public virtual IQueryable<T> AllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = ApplicationContext.Set<T>();

            return includeProperties.Aggregate(query,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public T GetSingle(long key)
        {
            return GetAll().FirstOrDefault(x => x.Id == key);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            var item = await ApplicationContext.Set<T>().FirstOrDefaultAsync(predicate);
            return item;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = AllIncluding(includeProperties);
            var item = await query.FirstOrDefaultAsync(predicate);
            return item;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return ApplicationContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            ApplicationContext.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            var dbEntityEntry = ApplicationContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var dbEntityEntry = ApplicationContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }


        public virtual void Delete(long entityId)
        {
            var entity = FindBy(x => x.Id == entityId)
                .SingleOrDefault();
            Delete(entity);
            SaveChanges();
        }

    }
}
