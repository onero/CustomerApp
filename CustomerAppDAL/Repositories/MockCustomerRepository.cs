using System.Collections.Generic;
using System.Linq;
using CustomerAppEntity;

namespace CustomerAppDAL.Repositories
{
    public class MockCustomerRepository : IRepository<Customer>
    {
        public Customer Create(Customer customerToCreate)
        {
            if (CustomerExists(customerToCreate)) return null;
            if (CustomerIsEmpty(customerToCreate)) return null;

            var newCustomer = new Customer
            {
                Id = _id++,
                FirstName = customerToCreate.FirstName,
                LastName = customerToCreate.LastName,
                Address = customerToCreate.Address
            };
            _customers.Add(newCustomer);
            return newCustomer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return new List<Customer>(_customers);
        }

        public Customer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public bool Delete(int id)
        {
            var customerToDelete = GetById(id);
            if (customerToDelete == null) return false;
            _customers.Remove(customerToDelete);
            return true;
        }

        private bool CustomerIsEmpty(Customer customerToCreate)
        {
            return customerToCreate.FirstName == null
                   || customerToCreate.LastName == null
                   || customerToCreate.Address == null;
        }

        private bool CustomerExists(Customer customerToCreate)
        {
            return _customers.Exists(c =>
                c.FirstName.Equals(customerToCreate.FirstName) &&
                c.LastName.Equals(customerToCreate.LastName) &&
                c.Address.Equals(customerToCreate.Address));
        }

        #region FakeDB

        private int _id = 1;

        private readonly List<Customer> _customers = new List<Customer>
        {
            new Customer
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            },

            new Customer
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            }
        };

        #endregion
    }
}