using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GAPRepository
{
    public partial interface IGenericRepository<TEntity, TDBContext>
    {
        IEnumerable<TEntity> GetEnumerableCollection(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        IQueryable<TEntity> GetQueryableCollection(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        IList<TEntity> GetListCollection(
           Expression<Func<TEntity, bool>> filter = null,
           string includeProperties = "");
        TEntity GetEntityById(object id);
        void Insert(TEntity entityToInsert);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate, Object id);
        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
        int UpdateFields(string query, params object[] parameters);
    }
}

