using System.Collections.Generic;

namespace CustomerAppDAL
{
    /// <summary>
    ///     Interface for CRUD operations on a DB
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity customerToCreate);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        bool Delete(int id);
    }
}