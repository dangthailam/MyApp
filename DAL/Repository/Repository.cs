using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IDbContext _dbContext;

        private IDbSet<TEntity> _dbSet;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format("Entity {0} is null", entity.GetType().FullName));
            _dbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            Delete(_dbSet.Find(id));
        }

        public void DeleteRange(ICollection<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Queryable()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
