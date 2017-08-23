using CustomerAppBLL.Services;
using CustomerAppDAL;
using CustomerAppDAL.UnitOfWork;
using CustomerAppEntity;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public IService<Customer> CustomerService =>
            new CustomerService(new DALFacade().UnitOfWork);
    }
}