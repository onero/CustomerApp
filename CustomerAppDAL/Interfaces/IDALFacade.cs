using CustomerAppDAL.Interfaces;

namespace CustomerAppDAL
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}