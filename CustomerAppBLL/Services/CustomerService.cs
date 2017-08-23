using System;
using System.Collections.Generic;
using CustomerAppDAL;
using CustomerAppDAL.UnitOfWork;
using CustomerAppEntity;

namespace CustomerAppBLL.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly DALFacade _dalFacade = DALFacade.Instance;
        

        public Customer Create(Customer customerToCreate)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var createdCustomer = unitOfWork.CustomerRepository().Create(customerToCreate);
                unitOfWork.Save();
                return createdCustomer;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
                return unitOfWork.CustomerRepository().GetAll();
        }

        public Customer GetById(int id)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
                return unitOfWork.CustomerRepository().GetById(id);
        }

        public bool Delete(int id)
        {
            using (var unitOfWork = _dalFacade.UnitOfWork)
            {
                var customerDeleted = unitOfWork.CustomerRepository().Delete(id);
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