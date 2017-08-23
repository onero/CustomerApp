using System.Collections.Generic;
using CustomerAppEntity;

namespace CustomerAppDAL.Context
{
    public class MockContext
    {
        public readonly List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            },

            new Customer
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            }
        };
    }
}