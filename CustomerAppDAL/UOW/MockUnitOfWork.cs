﻿using CustomerAppDAL.Repositories;
using CustomerAppEntity;

namespace CustomerAppDAL.UOW
{
    internal class MockUnitOfWork : IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; }

        public MockUnitOfWork()
        {
            CustomerRepository = new MockCustomerRepository();
        }

        public int Complete()
        {
            return 0;
        }

        public void Dispose()
        {
        }
    }
}