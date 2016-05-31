using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace GAPRepository
{
    public class GenericRepository<TEntity, TDBContext> : IGenericRepository<TEntity, TDBContext>
        where TEntity : class
        where TDBContext : DbContext
    {
        internal TDBContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(TDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();

        }

        public virtual IEnumerable<TEntity> GetEnumerableCollection(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IQueryable<TEntity> GetQueryableCollection(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public IList<TEntity> GetListCollection(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IList<TEntity> query = dbSet.ToList<TEntity>();
                       

            if (filter != null)
            {
                throw new NotImplementedException();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                throw new NotImplementedException();
            }

            return query;
        }

        public virtual TEntity GetEntityById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate, Object entityId)
        {
            TEntity originalEntity = dbSet.Find(entityId);
            context.Entry(originalEntity).State = EntityState.Detached;
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual int UpdateFields(string query, params object[] parameters)
        {

            return context.Database.ExecuteSqlCommand(query, parameters);
        }
               
    }        
}
