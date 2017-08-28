using CustomerAppDAL.Context;
using CustomerAppDAL.Entities;
using CustomerAppDAL.Interfaces;
using CustomerAppDAL.Repositories;

namespace CustomerAppDAL.UOW
{
    internal class UnitOfWorkMem : IUnitOfWork
    {
        private readonly InMemoryContext _context;


        public UnitOfWorkMem()
        {
            _context = new InMemoryContext();
            CustomerRepository = new CustomerRepositoryEFMemory(_context);
        }

        public IRepository<Customer> CustomerRepository { get; }

        public int Complete()
        {
            // Return the number of objects written to the underlying database
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}