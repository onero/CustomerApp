using CustomerAppDAL.Entities;
using CustomerAppDAL.Interfaces;
using CustomerAppDAL.Repositories;

namespace CustomerAppDAL.UOW
{
    internal class MockUnitOfWork : IUnitOfWork
    {
        public MockUnitOfWork()
        {
            CustomerRepository = new MockCustomerRepository();
        }

        public IRepository<Customer> CustomerRepository { get; }

        public int Complete()
        {
            return 0;
        }

        public void Dispose()
        {
        }
    }
}