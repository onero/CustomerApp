using CustomerAppDAL.UnitOfWork;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        private static DALFacade _instance;

        public static DALFacade Instance => _instance ?? (_instance = new DALFacade());

        //public IRepository<Customer> CustomerRepository => 
        //    new CustomerRepositoryEFMemory(
        //        new InMemoryContext());

        public IUnitOfWork UnitOfWork => new UnitOfWork.UnitOfWork();
    }
}