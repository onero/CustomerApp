using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.Services;

namespace CustomerAppBLL
{
    public class BllFacade
    {
        private static BllFacade _instance;

        public static BllFacade Instance => _instance ?? (_instance = new BllFacade());

        public ICustomerService CustomerService => new CustomerService();
    }
}