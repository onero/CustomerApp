using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Services
{
    public class CustomerService : IService<CustomerBO>
    {
        private readonly IDALFacade _dalFacade;

        public CustomerService(IDALFacade facade)
        {
            _dalFacade = facade;
        }

        public CustomerBO Create(CustomerBO customerToCreate)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Create(Convert(customerToCreate));
                uow.Complete();
                return Convert(newCustomer);
            }
        }

        public IList<CustomerBO> CreateAll(IList<CustomerBO> customers)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var listOfCustomers = new List<CustomerBO>();
                foreach (var customer in customers)
                {
                    var createdCustomer = uow.CustomerRepository.Create(Convert(customer));
                    listOfCustomers.Add(Convert(createdCustomer));
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
                return uow.CustomerRepository.GetAll().Select(Convert).ToList();
            }
        }

        public CustomerBO GetById(int id)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                return Convert(uow.CustomerRepository.GetById(id));
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
                return Convert(customerFromDb);
            }
        }

        /// <summary>
        /// Convert CustomerBO to Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Customer</returns>
        private Customer Convert(CustomerBO customer)
        {
            return new Customer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address
            };
        }

        /// <summary>
        /// Convert Customer to CustomerBO
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>CustomerBO</returns>
        private CustomerBO Convert(Customer customer)
        {
            return new CustomerBO()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address
            };
        }
    }
}