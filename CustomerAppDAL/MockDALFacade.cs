using CustomerAppDAL.Interfaces;
using CustomerAppDAL.UOW;

namespace CustomerAppDAL
{
    public class MockDALFacade :IDALFacade
    {
        public IUnitOfWork UnitOfWork => new MockUnitOfWork();
    }
}