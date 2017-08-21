using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAppEntity;

namespace CustomerAppDAL.Repositories
{
    internal class CustomerRepositoryFakeDB : ICustomerRepository
    {
        #region FakeDB
        private static int _id = 1;
        private static readonly List<Customer> Customers = new List<Customer>();
        #endregion

        public Customer CreateCustomer(Customer customerToCreate)
        {
            Customer newCustomer;
            Customers.Add(newCustomer = new Customer()
            {
                Id = _id++,
                FirstName = customerToCreate.FirstName,
                LastName = customerToCreate.LastName,
                Address = customerToCreate.Address
            });
            return newCustomer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>(Customers);
        }

        public Customer GetCustomerById(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
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
            Customers.Remove(customerToDelete);
            return true;
        }
    }
}