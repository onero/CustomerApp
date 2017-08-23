using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppDAL.UnitOfWork
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; }

        public MockUnitOfWork()
        {
            var context = new MockContext();
            CustomerRepository = new MockCustomerRepository(context);
        }
        public void Save()
        {
        }

        public void Dispose()
        {
        }
    }
}