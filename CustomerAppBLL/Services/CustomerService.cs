using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAL;
using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly IRepository<Customer> _repo;

        public CustomerService(IRepository<Customer> repo)
        {
            _repo = repo;
        }
        public Customer Create(Customer customerToCreate)
        {
            return _repo.Create(customerToCreate);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _repo.GetAll();
        }

        public Customer GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Customer Update(Customer updatedCustomer)
        {
            var customerFromDb = GetById(updatedCustomer.Id);
            if (customerFromDb == null) throw new InvalidOperationException("Customer doesn't exist in DB");

            customerFromDb.FirstName = updatedCustomer.FirstName;
            customerFromDb.LastName = updatedCustomer.LastName;
            customerFromDb.Address = updatedCustomer.Address;
            return customerFromDb;
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}