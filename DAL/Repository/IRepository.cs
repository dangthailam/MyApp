namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Find(params object[] keyValues);
        void Update(TEntity entity);
    }
}
