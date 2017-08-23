using CustomerAppDAL.Context;

namespace CustomerAppDAL
{
    public class DALFacade
    {

        //public IRepository<Customer> CustomerRepository => 
        //    new CustomerRepository(
        //        new InMemoryContext());

        public IUnitOfWork UnitOfWork => new UnitOfWork.UnitOfWork();
    }
}