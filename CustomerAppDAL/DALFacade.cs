using CustomerAppDAL.Interfaces;
using CustomerAppDAL.UOW;

namespace CustomerAppDAL
{
    public class DALFacade : IDALFacade
    {
        public IUnitOfWork UnitOfWork => new UnitOfWorkMem();
    }
}