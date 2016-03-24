using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void DeleteRange(ICollection<TEntity> list);
        TEntity Find(params object[] keyValues);
        IRepository<T> GetRepository<T>() where T : class;
        void InsertRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Update(TEntity entity);
    }
}
