using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAL;
using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    internal class CustomerService : ICustomerService
    {
        public Customer CreateCustomer(Customer customerToCreate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}