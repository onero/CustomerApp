using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;
using CustomerAppDAL.UOW;
using CustomerAppEntity;

namespace CustomerAppDAL
{
    public class DALFacade : IDALFacade
    {
        public IUnitOfWork UnitOfWork => new UnitOfWorkMem();
    }
}