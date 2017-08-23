using CustomerAppBLL.Services;
using CustomerAppDAL;
using CustomerAppEntity;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        private readonly DALFacade _dalFacade = DALFacade.Instance;

        public IService<Customer> CustomerService => 
            new CustomerService();
    }
}