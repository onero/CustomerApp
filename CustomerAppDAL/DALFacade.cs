using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public IRepository<Customer> CustomerRepository => new MockCustomerRepository();
    }
}