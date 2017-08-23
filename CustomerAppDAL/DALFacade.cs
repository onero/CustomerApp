using CustomerAppDAL.Context;

namespace CustomerAppDAL
{
    public class DALFacade
    {

        //public IRepository<Customer> CustomerRepository => 
        //    new CustomerRepositoryEFMemory(
        //        new InMemoryContext());

        public IUnitOfWork UnitOfWork => new UnitOfWork.UnitOfWork(new InMemoryContext());
    }
}