﻿using System;
using CustomerAppEntity;

namespace CustomerAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> CustomerRepository { get; }

        int Save();
    }
}