using System;
using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppDAL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly InMemoryContext _context = new InMemoryContext();
        public IRepository<Customer> CustomerRepository()=> 
            new CustomerRepositoryEFMemory(_context);

        
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