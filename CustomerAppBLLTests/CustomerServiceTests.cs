using System.Collections.Generic;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Services;
using CustomerAppDAL;
using CustomerAppDAL.Entities;
using Xunit;

namespace CustomerAppBLLTests
{
    public class CustomerServiceTests
    {
        public CustomerServiceTests()
        {
            IDALFacade dalFacade = new MockDALFacade();
            _customerService = new CustomerService(dalFacade);
        }

        private readonly IService<CustomerBO> _customerService;

        private static readonly CustomerBO MockCustomer = new CustomerBO
        {
            FirstName = "Test",
            LastName = "Testesen",
            Address = "Secret"
        };

        //[Fact]
        //public void TestCreateAllSuccess()
        //{
        //    var listOfNewCustomers = new List<CustomerBO>
        //    {
        //        MockCustomer,
        //        new CustomerBO {FirstName = "Test2", LastName = "Testesen", Address = "Test"}
        //    };

        //    var createdCustomers = _customerService.CreateAll(listOfNewCustomers);

        //    Assert.False(createdCustomers.Contains(null));
        //}

        //[Fact]
        //public void TestCreateDuplicateFail()
        //{
        //    var listOfCustomers = new List<CustomerBO>
        //    {
        //        MockCustomer,
        //        MockCustomer
        //    };

        //    var createdCustomers = _customerService.CreateAll(listOfCustomers);

        //    Assert.Null(createdCustomers[1]);
        //}

        //[Fact]
        //public void TestCreateEmptyFail()
        //{
        //    var newCustomer = new CustomerBO();

        //    var createdCustomer = _customerService.Create(newCustomer);

        //    Assert.Null(createdCustomer);
        //}

        //[Fact]
        //public void TestCreateSuccess()
        //{
        //    var createdCustomer = _customerService.Create(MockCustomer);

        //    Assert.NotNull(createdCustomer);
        //}


        //[Fact]
        //public void TestDeleteSuccess()
        //{
        //    var deleteSucceeded = _customerService.Delete(1);

        //    Assert.True(deleteSucceeded);
        //}

        //[Fact]
        //public void TestGetAll()
        //{
        //    var customers = _customerService.GetAll();

        //    Assert.NotNull(customers);
        //}

        //[Fact]
        //public void TestGetById()
        //{
        //    var customerFromSearch = _customerService.GetById(1);

        //    Assert.NotNull(customerFromSearch);
        //}
    }
}