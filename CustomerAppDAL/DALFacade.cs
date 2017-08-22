using CustomerAppDAL.Repositories;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        private static DALFacade _instance;

        public static DALFacade Instance => _instance ?? (_instance = new DALFacade());

        public ICustomerRepository CustomerRepository => new CustomerRepositoryFakeDB();
    }
}