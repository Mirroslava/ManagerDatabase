using System;
using System.Collections.Generic;

namespace ManagerDatabase
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity FindById(Guid id);
        IEnumerable<TEntity> Get();
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
    }
}
