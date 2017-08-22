using CustomerAppBLL.Services;
using CustomerAppDAL;
using CustomerAppEntity;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public IService<Customer> CustomerService => new CustomerService(new DALFacade().CustomerRepository);
    }
}