using ordinacija_be.Data.Repositories;

namespace ordinacija_be.Data
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        void SaveChanges();
    }
}