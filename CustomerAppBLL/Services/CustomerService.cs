using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAL;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    class CustomerService : ICustomerService
    {
        public Customer CreateCustomer(Customer customerToCreate)
        {
            Customer newCustomer;
            FakeDB.Customers.Add(newCustomer = new Customer()
            {
                Id = FakeDB.Id++,
                FirstName = customerToCreate.FirstName,
                LastName = customerToCreate.LastName,
                Address = customerToCreate.Address
            });
            return newCustomer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>(FakeDB.Customers);
        }

        public Customer GetCustomerById(int id)
        {
            return FakeDB.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            var customerFromDb = GetCustomerById(updatedCustomer.Id);
            if (customerFromDb == null) throw new InvalidOperationException("Customer doesn't exist in DB");

            customerFromDb.FirstName = updatedCustomer.FirstName;
            customerFromDb.LastName = updatedCustomer.LastName;
            customerFromDb.Address = updatedCustomer.Address;
            return customerFromDb;
        }

        public bool DeleteCustomer(int id)
        {
            var customerToDelete = GetCustomerById(id);
            if (customerToDelete == null) return false;
            FakeDB.Customers.Remove(customerToDelete);
            return true;
        }
    }
}
