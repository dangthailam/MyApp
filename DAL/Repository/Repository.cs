using DAL.DataContext;
using System;
using System.Data.Entity;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IDbContext _dbContext;

        private DbSet<TEntity> _dbSet;

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

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
        
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            (_dbContext as DbContext).Entry(entity).State = EntityState.Modified;
        }
    }
}
