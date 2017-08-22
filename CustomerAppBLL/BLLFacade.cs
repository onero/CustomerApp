using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.Services;
using CustomerAppDAL;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        private static BLLFacade _instance;

        private readonly DALFacade _dalFacade = DALFacade.Instance;

        public static BLLFacade Instance => _instance ?? (_instance = new BLLFacade());

        public ICustomerService CustomerService => new CustomerService(_dalFacade.CustomerRepository);
        
    }
}