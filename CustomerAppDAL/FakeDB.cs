using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppEntity;

namespace CustomerAppDAL
{
    public class FakeDB
    {
        private static int _id = 1;
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer{Id = _id++, FirstName = "Test1", LastName = "Testesen", Address = "Secret"},
            new Customer{Id = _id++, FirstName = "Test2", LastName = "Testesen", Address = "Secret"},
            new Customer{Id = _id++, FirstName = "Test3", LastName = "Testesen", Address = "Secret"},
            new Customer{Id = _id++, FirstName = "Test4", LastName = "Testesen", Address = "Secret"}
        };

        public static Customer CreateCustomer(Customer newCustomer)
        {
            newCustomer.Id = _id++;
            Customers.Add(newCustomer);
            return newCustomer;
        }
    }
}
