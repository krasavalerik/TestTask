using System.Collections.Generic;

namespace MyClassLibrary
{
    public interface IRepository<TEntity> where TEntity : class
    {
        long Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        TEntity Remove(int id);
        TEntity Update(int id, TEntity entity);
    }
}
