using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CustomerAppDAL;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly IDALFacade _dalFacade;

        public CustomerService(IDALFacade facade)
        {
            _dalFacade = facade;
        }

        public Customer Create(Customer customerToCreate)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var newCustomer = uow.CustomerRepository.Create(customerToCreate);
                uow.Complete();
                return newCustomer;
            }
        }

        public IList<Customer> CreateAll(IList<Customer> customers)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var listOfCustomers = new List<Customer>();
                foreach (var customer in customers)
                {
                    var createdCustomer = uow.CustomerRepository.Create(customer);
                    listOfCustomers.Add(createdCustomer);
                }
                uow.Complete();
                return listOfCustomers;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                return uow.CustomerRepository.GetAll();
            }
        }

        public Customer GetById(int id)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                return uow.CustomerRepository.GetById(id);
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

        public Customer Update(Customer updatedCustomer)
        {
            using (var uow = _dalFacade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.GetById(updatedCustomer.Id);
                if (customerFromDb == null) throw new InvalidOperationException("Customer doesn't exist in DB");

                customerFromDb.FirstName = updatedCustomer.FirstName;
                customerFromDb.LastName = updatedCustomer.LastName;
                customerFromDb.Address = updatedCustomer.Address;
                uow.Complete();
                return customerFromDb;

            }
            
        }
    }
}