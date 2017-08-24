using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppDAL.UOW
{
    internal class UnitOfWorkMem : IUnitOfWork
    {
        private readonly InMemoryContext _context;

        public IRepository<Customer> CustomerRepository { get; }


        public UnitOfWorkMem(InMemoryContext context)
        {
            _context = context;
            CustomerRepository = new CustomerRepositoryEFMemory(_context);
        }

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