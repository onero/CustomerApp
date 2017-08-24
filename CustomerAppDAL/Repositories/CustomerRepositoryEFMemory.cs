using System.Collections.Generic;
using System.Linq;
using CustomerAppDAL.Context;
using CustomerAppEntity;

namespace CustomerAppDAL.Repositories
{
    public class CustomerRepositoryEFMemory : IRepository<Customer>
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
            return _context.Customers.ToList();
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