using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppBLL;
using CustomerAppEntity;

namespace CustomerAppUI.Model
{
    public class CustomerModel : ICustomerService
    {
        private readonly IList<Customer> _customers;
        private readonly BllFacade _bllFacade;

        public CustomerModel()
        {
            _bllFacade = BllFacade.Instance;
            _customers = new List<Customer>(_bllFacade.CustomerService.GetAllCustomers());
        }

        /// <summary>
        /// Search for customer by name
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public Customer SearchForCustomerName(string searchString)
        {
            return _customers.FirstOrDefault(c => c.GetFullName().Contains(searchString));
        }

        public Customer CreateCustomer(Customer customerToCreate)
        {
            var createdCustomer = _bllFacade.CustomerService.CreateCustomer(customerToCreate);
            _customers.Add(createdCustomer);
            return createdCustomer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>(_customers);
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.SingleOrDefault(c => c.Id == id);
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            return _bllFacade.CustomerService.UpdateCustomer(updatedCustomer);
        }

        public bool DeleteCustomer(int id)
        {
            var customerDeleted = _bllFacade.CustomerService.DeleteCustomer(id);
            if (customerDeleted)
            {
                _customers.Remove(GetCustomerById(id));
                return true;
            }
            return false;
        }
    }
}