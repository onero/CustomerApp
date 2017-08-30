﻿using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Services
{
    public class CustomerService : IService<CustomerBO>
    {
        private readonly IDALFacade _dalFacade;

        private readonly CustomerConverter _converter;

        public CustomerService(IDALFacade facade)
        {
            _dalFacade = facade;
            _converter = new CustomerConverter();
        }

        public CustomerBO Create(CustomerBO customerToCreate)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Create(_converter.Convert(customerToCreate));
                uow.Complete();
                return _converter.Convert(newCustomer);
            }
        }

        public IList<CustomerBO> CreateAll(IList<CustomerBO> customers)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var listOfCustomers = new List<CustomerBO>();
                foreach (var customer in customers)
                {
                    var createdCustomer = uow.CustomerRepository.Create(_converter.Convert(customer));
                    listOfCustomers.Add(_converter.Convert(createdCustomer));
                }
                uow.Complete();
                return listOfCustomers;
            }
        }

        public IEnumerable<CustomerBO> GetAll()
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                // Customer -> CustomerBO
                return uow.CustomerRepository.GetAll().Select(_converter.Convert).ToList();
            }
        }

        public CustomerBO GetById(int id)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                return _converter.Convert(uow.CustomerRepository.GetById(id));
            }
        }

        public bool Delete(int id)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var customerDeleted = uow.CustomerRepository.Delete(id);
                uow.Complete();
                return customerDeleted;
            }
        }

        public CustomerBO Update(CustomerBO updatedCustomer)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.GetById(updatedCustomer.Id);
                if (customerFromDb == null) throw new InvalidOperationException("Customer doesn't exist in DB");

                customerFromDb.FirstName = updatedCustomer.FirstName;
                customerFromDb.LastName = updatedCustomer.LastName;
                customerFromDb.Address = updatedCustomer.Address;
                uow.Complete();
                return _converter.Convert(customerFromDb);
            }
        }

        
    }
}