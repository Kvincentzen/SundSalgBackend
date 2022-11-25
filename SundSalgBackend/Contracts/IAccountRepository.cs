using SundSalgBackend.Models;
using SundSalgBackend.Models.DataTransferObjects;

namespace SundSalgBackend.Contracts
{
    public interface IAccountRepository : IRepositoryBase<User>
    {

        void UpdateAccount(User user);
        void DeleteAccount(User user);
    }
}
