using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.Services;

namespace CustomerAppBLL
{
    public class BllFacade
    {
        public ICustomerService CustomerService => new CustomerService();
    }
}