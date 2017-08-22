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

        public static BLLFacade Instance => _instance ?? (_instance = new BLLFacade());

        public ICustomerService CustomerService => new CustomerService(new DALFacade().CustomerRepository);
        
    }
}