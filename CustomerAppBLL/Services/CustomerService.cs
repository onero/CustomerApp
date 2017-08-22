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
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public Customer CreateCustomer(Customer customerToCreate)
        {
            return _repo.CreateCustomer(customerToCreate);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _repo.GetCustomerById(id);
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
            return _repo.DeleteCustomer(id);
        }
    }
}