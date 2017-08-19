using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer CreateCustomer(Customer customerToCreate)
        {
            return FakeDB.CreateCustomer(customerToCreate);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>(FakeDB.Customers);
        }

        public Customer GetCustomerById(int id)
        {
            return FakeDB.Customers.Find(c => c.Id == id);
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            var customerToUpdate = GetCustomerById(updatedCustomer.Id);
            customerToUpdate.Address = updatedCustomer.Address;
            customerToUpdate.FirstName = updatedCustomer.FirstName;
            customerToUpdate.LastName = updatedCustomer.LastName;
            return customerToUpdate;
        }

        public bool DeleteCustomer(int id)
        {
            var customerToRemove = GetCustomerById(id);
            return FakeDB.Customers.Remove(customerToRemove);
        }
    }
}
