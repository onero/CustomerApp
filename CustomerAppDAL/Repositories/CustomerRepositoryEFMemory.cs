using System.Collections.Generic;
using System.Linq;
using CustomerAppDAL.Context;
using CustomerAppDAL.Entities;
using CustomerAppDAL.Interfaces;

namespace CustomerAppDAL.Repositories
{
    internal class CustomerRepositoryEFMemory : IRepository<Customer>
    {
        private readonly InMemoryContext _context;

        public CustomerRepositoryEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Customer Create(Customer customerToCreate)
        {
            _context.Customers.Add(customerToCreate);
            return customerToCreate;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public bool Delete(int id)
        {
            var customer = GetById(id);
            _context.Customers.Remove(customer);
            return true;
        }
    }
}