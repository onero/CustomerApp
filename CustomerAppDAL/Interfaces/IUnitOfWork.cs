using System;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> CustomerRepository { get; }

        int Complete();
    }
}