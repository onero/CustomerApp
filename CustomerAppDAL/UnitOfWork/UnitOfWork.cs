using System;
using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InMemoryContext _context;

        public IRepository<Customer> CustomerRepository { get; }

        public UnitOfWork()
        {
            _context = new InMemoryContext();
            CustomerRepository = new CustomerRepositoryEFMemory(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}