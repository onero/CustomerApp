using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Services;
using CustomerAppDAL;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public IService<CustomerBO> CustomerService => new CustomerService(new DALFacade());
    }
}