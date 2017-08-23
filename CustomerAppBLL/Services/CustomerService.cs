using System;
using System.Collections.Generic;
using CustomerAppDAL;
using CustomerAppDAL.Context;
using CustomerAppDAL.UnitOfWork;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    public class CustomerService : IService<Customer>
    {
        public Customer Create(Customer customerToCreate)
        {
            if (CustomerIsEmpty(customerToCreate)) return null;
            using (var unitOfWork = new UnitOfWork(new InMemoryContext()))
            {
                var createdCustomer = unitOfWork.CustomerRepository.Create(customerToCreate);
                unitOfWork.Save();
                return createdCustomer;
            }
        }

        private bool CustomerIsEmpty(Customer customerToCreate)
        {
            return customerToCreate.FirstName == null
                   || customerToCreate.LastName == null
                   || customerToCreate.Address == null;
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(new InMemoryContext()))
                return unitOfWork.CustomerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            using (var unitOfWork = new UnitOfWork(new InMemoryContext()))
                return unitOfWork.CustomerRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            using (var unitOfWork = new UnitOfWork(new InMemoryContext()))
            {
                var customerDeleted = unitOfWork.CustomerRepository.Delete(id);
                unitOfWork.Save();
                return customerDeleted;
            }
        }

        public Customer Update(Customer updatedCustomer)
        {
            throw new NotImplementedException("Remember to implement this!");
        }
    }
}