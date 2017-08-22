using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppEntity;

namespace CustomerAppBLL
{
    /// <summary>
    /// Entity Interface for basic CRUD with DAL
    /// </summary>
    public interface IService<TEntity>
    {
        TEntity Create(TEntity entityToCreate);
        
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
        
        bool Delete(int id);
    }
}