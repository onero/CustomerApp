using CustomerAppBLL;
using CustomerAppBLL.Services;
using CustomerAppDAL;
using CustomerAppDAL.Repositories;
using CustomerAppDAL.UnitOfWork;
using CustomerAppEntity;
using Xunit;

namespace CustomerAppBLLTests
{
    public class CustomerServiceTests
    {
        private readonly IService<Customer> _customerService;

        public CustomerServiceTests()
        {
            var mockUnitOfWork = new MockUnitOfWork();
            _customerService = new CustomerService(mockUnitOfWork);
        }

        private static readonly Customer MockCustomer = new Customer
        {
            FirstName = "Test",
            LastName = "Testesen",
            Address = "Secret"
        };

        [Fact]
        public void TestCreateDuplicateFail()
        {
            var created1 = _customerService.Create(MockCustomer);
            var created2 = _customerService.Create(MockCustomer);

            Assert.Null(created2);
        }

        [Fact]
        public void TestCreateEmptyFail()
        {
            var newCustomer = new Customer();

            var createdCustomer = _customerService.Create(newCustomer);

            Assert.Null(createdCustomer);
        }

        [Fact]
        public void TestCreateSuccess()
        {
            var createdCustomer = _customerService.Create(MockCustomer);

            Assert.NotNull(createdCustomer);
        }


        [Fact]
        public void TestDeleteSuccess()
        {
            var newPerson = _customerService.Create(MockCustomer);

            var deleteSucceeded = _customerService.Delete(newPerson.Id);

            Assert.True(deleteSucceeded);
        }

        [Fact]
        public void TestGetAll()
        {
            var customers = _customerService.GetAll();

            Assert.NotNull(customers);
        }

        [Fact]
        public void TestGetById()
        {
            var createdCustomer = _customerService.Create(MockCustomer);

            var customerFromSearch = _customerService.GetById(createdCustomer.Id);

            Assert.Equal(createdCustomer, customerFromSearch);
        }
    }
}