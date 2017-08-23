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
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer Create(Customer customerToCreate)
        {
            if (CustomerIsEmpty(customerToCreate)) return null;
            using (var unitOfWork = _unitOfWork)
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
            using (var unitOfWork = _unitOfWork)
                return unitOfWork.CustomerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            using (var unitOfWork = _unitOfWork)
                return unitOfWork.CustomerRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            using (var unitOfWork = _unitOfWork)
            {
                var customerDeleted = unitOfWork.CustomerRepository.Delete(id);
                unitOfWork.Save();
                return customerDeleted;
            }
        }
    }
}