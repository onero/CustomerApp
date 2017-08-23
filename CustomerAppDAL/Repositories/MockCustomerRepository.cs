using System.Collections.Generic;
using System.Linq;
using CustomerAppDAL.Context;
using CustomerAppEntity;

namespace CustomerAppDAL.Repositories
{
    public class MockCustomerRepository : IRepository<Customer>
    {
        private static int _id = 1;
        private readonly MockContext _mockContext;

        public MockCustomerRepository(MockContext mockContext)
        {
            _mockContext = mockContext;
        }

        public Customer Create(Customer customerToCreate)
        {
            if (CustomerExists(customerToCreate)) return null;

            var newCustomer = new Customer
            {
                Id = _id++,
                FirstName = customerToCreate.FirstName,
                LastName = customerToCreate.LastName,
                Address = customerToCreate.Address
            };
            _mockContext.Customers.Add(newCustomer);
            return newCustomer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return new List<Customer>(_mockContext.Customers);
        }

        public Customer GetById(int id)
        {
            return _mockContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public bool Delete(int id)
        {
            var customerToDelete = GetById(id);
            if (customerToDelete == null) return false;
            _mockContext.Customers.Remove(customerToDelete);
            return true;
        }

        private bool CustomerExists(Customer customerToCreate)
        {
            return _mockContext.Customers.Exists(c =>
                c.FirstName.Equals(customerToCreate.FirstName) &&
                c.LastName.Equals(customerToCreate.LastName) &&
                c.Address.Equals(customerToCreate.Address));
        }
    }
}