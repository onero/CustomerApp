using CustomerAppDAL.Repositories;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public ICustomerRepository CustomerRepository => new CustomerRepositoryFakeDB();
    }
}