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
            throw new NotImplementedException();
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