using System.Collections.Generic;

namespace CustomerAppDAL
{
    /// <summary>
    ///     Interface for CRUD operations on a DB
    /// </summary>
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entityToCreate);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        bool Delete(int id);
    }
}